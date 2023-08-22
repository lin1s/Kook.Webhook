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
        public string Token { get; set; }

        public string VerifyToken { get; set; }

        public string EncryptKey { get; set; }

        public string CommandPrefix { get; set; }

        public string BaseUrl { get; set; }
    }
}
