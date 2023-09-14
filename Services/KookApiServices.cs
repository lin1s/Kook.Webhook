using Json;
using Models.Emun;
using Models.Json;
using Models.Request.Guild;
using Models.Response;
using Newtonsoft.Json;
using System.Reflection;
using Tools;

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
        public BaseReturnMsg GuildList(GuildListSendMsg msgData = null)
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
            return SpeedLimiterHelper.CheckSpeedLimiter("guild/list", url);
        }

        /// <summary>
        /// 获取服务器详情
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildView(GuildViewSendMsg msgData)
        {
            return SpeedLimiterHelper.CheckSpeedLimiter("guild/list", "/v3/guild/view?guild_id=" + msgData.GuildID);
        }

        /// <summary>
        /// 获取服务器中的用户列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildUserList(GuildUserListSendMsg msgData)
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
            return SpeedLimiterHelper.CheckSpeedLimiter("guild/user-list", url);
        }

        /// <summary>
        /// 修改服务器中用户的昵称
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildNickName(GuildNickNameSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("guild/nickname", "/v3/guild/nickname", sendMsg);
        }

        /// <summary>
        /// 离开服务器
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildLeave(GuildLeaveSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("guild/leave", "/v3/guild/leave", sendMsg);
        }

        /// <summary>
        /// 踢出服务器
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildKickout(GuildKickoutSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("guild/kickout", "/v3/guild/leave", sendMsg);
        }

        /// <summary>
        /// 服务器静音闭麦列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildMuteList(GuildMuteListSendMsg msgData)
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
            return SpeedLimiterHelper.CheckSpeedLimiter("guild-mute/list", url);
        }

        /// <summary>
        /// 添加服务器静音或闭麦
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildMuteCreate(GuildMuteCreateSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("guild-mute/create", "/v3/guild-mute/create", sendMsg);
        }

        /// <summary>
        /// 删除服务器静音或闭麦
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildMuteDelete(GuildMuteDeleteSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("guild-mute/delete", "/v3/guild-mute/delete", sendMsg);
        }

        /// <summary>
        /// 服务器助力历史 需要有服务器管理权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildBoostHistroy(GuildBoostHistorySendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("guild-boost/history", "/v3/guild-boost/history", sendMsg);
        }
        #endregion

        #region AssetCreate  

        public AssetReturnMsg AssetCreate(Stream file)
        {
            Dictionary<string, Stream> postFile = new Dictionary<string, Stream>();
            postFile.Add("file", file);
            return SpeedLimiterHelper.CheckSpeedLimiter("asset/create", "/v3/asset/create", new Dictionary<string, string>(), postFile);

        }

        #endregion

        #region Message

        public BaseReturnMsg MessageCreate(SendMsgModel msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("message/create", "/v3/message/create", sendMsg);
        }

        #endregion

    }
}
