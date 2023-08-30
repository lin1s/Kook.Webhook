using Json;
using Models.Json;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Tools
{
    public static class KooKAPIHelpser
    {
        private static Config BaseConfig = ConfigHelper.GetBaseConfig();

        private static Dictionary<string, string> header = new Dictionary<string, string>
        {
            { "Authorization", "Bot " + BaseConfig.Token }
        };

        #region AssetCreate

        public static AssetReturnMsg AssetCreate(Stream file)
        {
            Dictionary<string, Stream> postFile = new Dictionary<string, Stream>();
            postFile.Add("file", file);
            return SpeedLimiterHelper.CheckSpeedLimiter("asset/create", "/v3/asset/create", new Dictionary<string, string>(),postFile);

        }

        #endregion

        #region Message

        public static BaseReturnMsg MessageCreate(SendMsgModel msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData);
            return SpeedLimiterHelper.CheckSpeedLimiter("message/create", "/v3/message/create", sendMsg);
        }

        #endregion
    }
}
