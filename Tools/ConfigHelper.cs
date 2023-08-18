using Microsoft.Extensions.Configuration;

namespace Tools
{
    public static class ConfigHelper
    {
        private static IConfiguration _appSetting { get; set; }

        public static void Init(IConfiguration appSetting)
        {
            _appSetting = appSetting;
        }

        public static Config GetBaseConfig()
        {
            return _appSetting.GetSection("Base").Get<Config>() ?? new Config();
        }
    }

    public class Config
    {
        public string Token { get; set; } = string.Empty;

        public string VerifyToken { get; set; } = string.Empty;

        public string EncryptKey { get; set; } = string.Empty;

        public string CommandPrefix { get; set;} = string.Empty;
    }
}
