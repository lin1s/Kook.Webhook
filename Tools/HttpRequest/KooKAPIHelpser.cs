using Json;
using Models.Emun;
using Models.Json;
using Models.Request.Guild;
using Models.Response;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Tools
{
    public static class KooKAPIHelpser
    {
        #region Guild

        public static BaseReturnMsg GuildList(GuildListSendMsg msgData = null)
        {
            string data = "";
            if (msgData != null)
            {
                if (!string.IsNullOrEmpty(msgData.page)) data += "&page=" + msgData.page;
                if (!string.IsNullOrEmpty(msgData.page)) data += "&page_size=" + msgData.page_size;
                if (msgData.sort_type != null && msgData.sort_field != null)
                {
                    string sort = "";
                    if (msgData.sort_type == SortType.Descending)
                    {
                        sort = "-";
                    }
                    sort += msgData.sort_field;
                    data += "&sort=" + sort;
                }
            }
            string url = "/v3/guild/list";
            if (!string.IsNullOrEmpty(data))
                url += "?" + data.Remove(0, 1);

            return SpeedLimiterHelper.CheckSpeedLimiter("guild/list", url);
        }

        #endregion

        #region AssetCreate

        public static AssetReturnMsg AssetCreate(Stream file)
        {
            Dictionary<string, Stream> postFile = new Dictionary<string, Stream>();
            postFile.Add("file", file);
            return SpeedLimiterHelper.CheckSpeedLimiter("asset/create", "/v3/asset/create", new Dictionary<string, string>(), postFile);

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
