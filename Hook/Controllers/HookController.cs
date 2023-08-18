﻿using Microsoft.AspNetCore.Mvc;
using Models;
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
        public readonly Config config = ConfigHelper.GetBaseConfig();

        [HttpPost]
        public async Task<IActionResult> Challenge()
        {
            Challenge data = null;

            try
            {
                StreamReader stream = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
                var body = await stream.ReadToEndAsync();
                //Encryption encryption = JsonConvert.DeserializeObject<Encryption>(body);
                //string strDecrypt = Tools.Tool.Decrypt(encryption.encrypt, config.EncryptKey);
                data = JsonConvert.DeserializeObject<Challenge>(body);

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

            if (data != null && data.d.type == MessageType.System && data.d.channel_type == ChannelType.WEBHOOK_CHALLENGE)
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
                              string text = commandJson.d.extra["kmarkdown"]?["raw_content"]?.ToString();
                              if (string.IsNullOrEmpty(text))
                                  return;
                              object obj = Activator.CreateInstance(type);
                              method.Invoke(obj, new object[] { commandJson });
                          }
                      }
                  }
              });


            return new JsonResult(new { code = "200" });
        }
    }
}
