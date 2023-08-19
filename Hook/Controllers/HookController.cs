using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Attribute;
using Models.Emun;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using Tools;

namespace Hook.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HookController : ControllerBase
    {
        private readonly Config config = ConfigHelper.GetBaseConfig();

        [HttpPost]
        public async Task<IActionResult> Challenge()
        {
            Challenge data = null;
            try
            {
                StreamReader stream = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
                var body = await stream.ReadToEndAsync();
                Encryption encryption = JsonConvert.DeserializeObject<Encryption>(body);
                string strDecrypt = Tool.Decrypt(encryption.encrypt, config.EncryptKey);
                data = JsonConvert.DeserializeObject<Challenge>(strDecrypt);

                if (data == null || data.d == null)
                {
                    return new JsonResult(new { code = "200" });
                }

                if (data.d.verify_token != config.VerifyToken)
                {
                    LogHelper.Default.Warn("验证token错误，请确认网络环境");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("数据解析错误", ex);
                return new JsonResult(new { code = "200" });
            }

            if (data.d.type == MessageType.System && data.d.channel_type == ChannelType.WEBHOOK_CHALLENGE)
            {
                return new JsonResult(new { challenge = data.d.challenge });
            }

            await Task.Run(() =>
              {
                  Challenge commandJson = data;
                  Assembly commandAssembly = Assembly.LoadFrom(@"bin\Debug\net6.0\Command.dll");
                  foreach (Type type in commandAssembly.GetTypes())
                  {
                      foreach (MethodInfo method in type.GetMethods())
                      {
                          var attrs = System.Attribute.GetCustomAttributes(method, typeof(KookCommandAttribute));
                          if (attrs.Length != 0)
                          {
                              string command = ((KookCommandAttribute)attrs[0]).GetCommand();
                              if (string.IsNullOrEmpty(commandJson.d.content))
                                  return;

                              if (!commandJson.d.content.StartsWith(config.CommandPrefix))
                                  return;

                              KeywordLocal local = ((KeywordLocalAttribute)attrs[0]).GetLocal();
                              switch (local)
                              {
                                  case KeywordLocal.Start:
                                      if (commandJson.d.content.Remove(commandJson.d.content.IndexOf(config.CommandPrefix),config.CommandPrefix.Length).Trim().StartsWith(command))
                                      {
                                          object obj = Activator.CreateInstance(type);
                                          method.Invoke(obj, new object[] { commandJson });
                                      }
                                      break;
                                  case KeywordLocal.End:
                                      if (commandJson.d.content.EndsWith(command))
                                      {
                                          object obj = Activator.CreateInstance(type);
                                          method.Invoke(obj, new object[] { commandJson });
                                      }
                                      break;
                                  case KeywordLocal.Contain:
                                  default:
                                      if (commandJson.d.content.Contains(command))
                                      {
                                          object obj = Activator.CreateInstance(type);
                                          method.Invoke(obj, new object[] { commandJson });
                                      }
                                      break;
                              }

                          }
                      }
                  }
              });

            return new JsonResult(new { code = "200" });
        }
    }
}
