using Models.Emun;
using Models.Request.Guild;
using Models.Response;
using Newtonsoft.Json;
using System.Reflection;
using Tools;
using static Models.Request.Message;
using static Models.Response.Asset;

namespace Services
{
    public class KookApiServices : IKookApiServices
    {
        private JsonSerializerSettings setting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        #region Guild

        /// <summary>
        /// 获取当前用户加入的服务器列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildList GuildList(GuildListSendMsg msgData)
        {
            string data = "";
            if (msgData != null)
            {
                if (!string.IsNullOrEmpty(msgData.Page)) data += "&page=" + msgData.Page;
                if (!string.IsNullOrEmpty(msgData.PageSize)) data += "&page_size=" + msgData.PageSize;
                if (msgData.SortType != null && msgData.SortField != null)
                {
                    string sort = "";
                    if (msgData.SortType == SortType.Descending)
                    {
                        sort = "-";
                    }
                    sort += msgData.SortField;
                    data += "&sort=" + sort;
                }
            }
            string url = "/v3/guild/list";
            if (!string.IsNullOrEmpty(data))
                url += "?" + data.Remove(0, 1);

            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("guild/list", url);
            return JsonConvert.DeserializeObject<GuildList>(msg.data.ToString());
        }

        /// <summary>
        /// 获取服务器详情
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildView GuildView(GuildViewSendMsg msgData)
        {
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("guild/list", "/v3/guild/view?guild_id=" + msgData.GuildID);
            return JsonConvert.DeserializeObject<GuildView>(msg.data.ToString());
        }

        /// <summary>
        /// 获取服务器中的用户列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildUserList GuildUserList(GuildUserListSendMsg msgData)
        {
            string data = "";
            Type type = msgData.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                var objValue = prop.GetValue(msgData);
                if (objValue != null)
                {
                    data += "&" + prop.Name + "=" + objValue;
                }
            }

            string url = "/v3/guild/user-list";
            if (!string.IsNullOrEmpty(data))
                url += "?" + data.Remove(0, 1);

            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("guild/user-list", url);
            return JsonConvert.DeserializeObject<GuildUserList>(msg.data.ToString());
        }

        /// <summary>
        /// 修改服务器中用户的昵称
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildNickName(GuildNickNameSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            SpeedLimiterHelper.CheckSpeedLimiter("guild/nickname", "/v3/guild/nickname", sendMsg);
        }

        /// <summary>
        /// 离开服务器
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildLeave(GuildLeaveSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            SpeedLimiterHelper.CheckSpeedLimiter("guild/leave", "/v3/guild/leave", sendMsg);
        }

        /// <summary>
        /// 踢出服务器
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildKickout(GuildKickOutSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            SpeedLimiterHelper.CheckSpeedLimiter("guild/kickout", "/v3/guild/leave", sendMsg);
        }

        /// <summary>
        /// 服务器静音闭麦列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildMuteList GuildMuteList(GuildMuteListSendMsg msgData)
        {
            string data = "";
            Type type = msgData.GetType();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                var objValue = prop.GetValue(msgData);
                if (objValue != null)
                {
                    data += "&" + prop.Name + "=" + objValue;
                }
            }

            string url = "/v3/guild-mute/list";
            if (!string.IsNullOrEmpty(data))
                url += "?" + data.Remove(0, 1);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("guild-mute/list", url);
            return JsonConvert.DeserializeObject<GuildMuteList>(msg.data.ToString());
        }

        /// <summary>
        /// 添加服务器静音或闭麦
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildMuteCreate(GuildMuteCreateSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            SpeedLimiterHelper.CheckSpeedLimiter("guild-mute/create", "/v3/guild-mute/create", sendMsg);
        }

        /// <summary>
        /// 删除服务器静音或闭麦
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildMuteDelete(GuildMuteDeleteSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            SpeedLimiterHelper.CheckSpeedLimiter("guild-mute/delete", "/v3/guild-mute/delete", sendMsg);
        }

        /// <summary>
        /// 服务器助力历史 需要有服务器管理权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildBoostHistroy GuildBoostHistroy(GuildBoostHistorySendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("guild-boost/history", "/v3/guild-boost/history", sendMsg);
            return JsonConvert.DeserializeObject<GuildBoostHistroy>(msg.data.ToString());
        }
        #endregion

        #region Channel


        #endregion

        #region AssetCreate  

        public AssetCreate AssetCreate(Stream file)
        {
            Dictionary<string, Stream> postFile = new Dictionary<string, Stream>();
            postFile.Add("file", file);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("asset/create", "/v3/asset/create", new Dictionary<string, string>(), postFile);
            return JsonConvert.DeserializeObject<AssetCreate>(msg.data.ToString());
        }

        #endregion

        #region Message

        public BaseReturnMsg MessageCreate(MessageCreateSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("message/create", "/v3/message/create", sendMsg);
        }

        #endregion

    }
}
