using Command.Base;
using Hook.Event;
using Microsoft.AspNetCore.Mvc;
using Models.Emun;
using Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private readonly IServiceProvider _serviceProvider;
        EventClass bindClass = new EventClass();

        public HookController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

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
                    Console.WriteLine("验证token错误，请确认网络环境");
                    LogHelper.Default.Warn("验证token错误，请确认网络环境");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("数据解析错误", ex);
                Console.WriteLine(ex.ToString());
                return new JsonResult(new { code = "200" });
            }

            if (data.d.type == MessageType.System && data.d.channel_type == ChallengeType.WEBHOOK_CHALLENGE)
            {
                return new JsonResult(new { challenge = data.d.challenge });
            }

#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            Task.Run(() =>
            {
                Challenge commandJson = data;

                var eventValue = commandJson.d.extra.Value<Models.Emun.Event>("type");
                switch (eventValue)
                {
                    case Models.Emun.Event.added_reaction :
                        bindClass.AddedReaction(commandJson);
                        break;
                    default:
                        break;
                }


                var assemblyAllTypes = typeof(BaseCommand).Assembly.GetTypes();
                foreach (var itemType in assemblyAllTypes)
                {
                    var baseType = itemType.BaseType;
                    if (baseType != null && baseType.Name == typeof(BaseCommand).Name && itemType.Name != typeof(BaseCommand).Name)
                    {
                        foreach (MethodInfo method in itemType.GetMethods())
                        {
                            string command = "";
                            KeywordLocal local = KeywordLocal.Contain;
                            var attrs = System.Attribute.GetCustomAttributes(method);
                            foreach (Attribute attr in attrs)
                            {
                                if (attr is KookCommandAttribute)
                                {
                                    command = ((KookCommandAttribute)attr).GetCommand();
                                    local = ((KookCommandAttribute)attr).GetLocal();

                                    if (string.IsNullOrEmpty(commandJson.d.content))
                                        return;

                                    if (!commandJson.d.content.StartsWith(config.CommandPrefix))
                                        return;

                                    ConstructorInfo[] properties = itemType.GetConstructors();
                                    ParameterInfo[] paramsList = properties[0].GetParameters();
                                    List<object> arg = new List<object>();

                                    foreach (ParameterInfo param in paramsList)
                                    {
                                        arg.Add(_serviceProvider.GetService(param.ParameterType));
                                    }

                                    switch (local)
                                    {
                                        case KeywordLocal.Start:
                                            if (commandJson.d.content.Remove(commandJson.d.content.IndexOf(config.CommandPrefix), config.CommandPrefix.Length).Trim().StartsWith(command))
                                            {
                                                object obj = ActivatorUtilities.CreateInstance(_serviceProvider, itemType);
                                                method.Invoke(obj, new object[] { commandJson });
                                                return;
                                            }
                                            break;
                                        case KeywordLocal.End:
                                            if (commandJson.d.content.EndsWith(command))
                                            {
                                                object obj = ActivatorUtilities.CreateInstance(_serviceProvider, itemType);
                                                method.Invoke(obj, new object[] { commandJson });
                                                return;
                                            }
                                            break;
                                        case KeywordLocal.Contain:
                                        default:
                                            if (commandJson.d.content.Contains(command))
                                            {
                                                object obj = ActivatorUtilities.CreateInstance(_serviceProvider, itemType);
                                                method.Invoke(obj, new object[] { commandJson });
                                                return;
                                            }
                                            break;
                                    }
                                }

                            }
                        }
                    }

                }
            });
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法

            return new JsonResult(new { code = "200" });
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Test()
        {
            return new JsonResult(new { code = "200", message = "测试成功" });
        }
    }
}
