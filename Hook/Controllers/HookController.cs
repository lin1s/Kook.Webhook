using Json;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Challenge()
        {
            Challenge data = null;
            try
            {
                StreamReader stream = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
                var body = stream.ReadToEndAsync().Result;
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

            Task.Run(() =>
              {
                  Challenge commandJson = data;
                  Assembly commandAssembly = Assembly.LoadFrom(@"Command.dll");
                  foreach (Type type in commandAssembly.GetTypes())
                  {
                      foreach (MethodInfo method in type.GetMethods())
                      {
                          string command = "";
                          KeywordLocal local = KeywordLocal.Contain;
                          var attrs = System.Attribute.GetCustomAttributes(method);

                          foreach (var attr in attrs)
                          {
                              if (attr is KookCommandAttribute)
                                  command = ((KookCommandAttribute)attr).GetCommand();
                              if (attr is KeywordLocalAttribute)
                                  local = ((KeywordLocalAttribute)attr).GetLocal();
                          }

                          if (!string.IsNullOrEmpty(command))
                          {
                              if (string.IsNullOrEmpty(commandJson.d.content))
                                  return;

                              if (!commandJson.d.content.StartsWith(config.CommandPrefix))
                                  return;

                              switch (local)
                              {
                                  case KeywordLocal.Start:
                                      if (commandJson.d.content.Remove(commandJson.d.content.IndexOf(config.CommandPrefix), config.CommandPrefix.Length).Trim().StartsWith(command))
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
