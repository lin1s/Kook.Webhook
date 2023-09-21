using Models.Emun;
using Models.Request;
using Models.Request.Guild;
using Models.Response;
using Newtonsoft.Json;
using System.Reflection;
using System.Reflection.Emit;
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
            string url = "/v3/guild/user-list?" + Tool.GetArgsInClass(msgData);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("guild/user-list", url);
            return JsonConvert.DeserializeObject<GuildUserList>(msg.data.ToString());
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
        public BaseReturnMsg GuildKickout(GuildKickOutSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("guild/kickout", "/v3/guild/leave", sendMsg);
        }

        /// <summary>
        /// 服务器静音闭麦列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildMuteList GuildMuteList(GuildMuteListSendMsg msgData)
        {
            string url = "/v3/guild-mute/list?" + Tool.GetArgsInClass(msgData);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("guild-mute/list", url);
            return JsonConvert.DeserializeObject<GuildMuteList>(msg.data.ToString());
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
        public GuildBoostHistroy GuildBoostHistroy(GuildBoostHistorySendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("guild-boost/history", "/v3/guild-boost/history", sendMsg);
            return JsonConvert.DeserializeObject<GuildBoostHistroy>(msg.data.ToString());
        }
        #endregion

        #region Channel

        /// <summary>
        /// 获取频道列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelList ChannelList(ChannelListSendMsg msgData)
        {
            string url = "/v3/channel/list?" + Tool.GetArgsInClass(msgData);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel/list", url);
            return JsonConvert.DeserializeObject<ChannelList>(msg.data.ToString());
        }

        /// <summary>
        /// 获取频道详情
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelView ChannelView(ChannelViewSendMsg msgData)
        {
            string url = "/v3/channel/view?" + Tool.GetArgsInClass(msgData);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel/list", url);
            return JsonConvert.DeserializeObject<ChannelView>(msg.data.ToString());
        }

        /// <summary>
        /// 创建频道
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelCreate ChannelCreate(ChannelCreateSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel/create", "/v3/channel/create", sendMsg);
            return JsonConvert.DeserializeObject<ChannelCreate>(msg.data.ToString());
        }

        /// <summary>
        /// 编辑频道
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelUpdate ChannelUpdate(ChannelUpdateSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel/update", "/v3/channel/update", sendMsg);
            return JsonConvert.DeserializeObject<ChannelUpdate>(msg.data.ToString());
        }

        /// <summary>
        /// 删除频道
        /// </summary>
        /// <param name="msgData"></param>
        public BaseReturnMsg ChannelDelete(ChannelDeleteSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("channel/delete", "/v3/channel/delete", sendMsg);
        }

        /// <summary>
        /// 语音频道用户列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public List<UserDetail> ChannelUserList(ChannelUserListSendMsg msgData)
        {
            string url = "/v3/channel/user-list?" + Tool.GetArgsInClass(msgData);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel/user-list", url);
            return JsonConvert.DeserializeObject<List<UserDetail>>(msg.data.ToString());
        }

        /// <summary>
        /// 语音频道之间移动用户
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg ChannelMoveUser(ChannelMoveUserSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("channel/move-user", "/v3/channel/move-user", sendMsg);
        }

        /// <summary>
        /// 频道角色权限详情
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelRoleIndex ChannelRoleIndex(ChannelRoleIndexSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel-role/index", "/v3/channel-role/index", sendMsg);
            return JsonConvert.DeserializeObject<ChannelRoleIndex>(msg.data.ToString());
        }

        /// <summary>
        /// 创建频道角色权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelRoleCreate ChannelRoleCreate(ChannelRoleCreateSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel-role/create", "/v3/channel-role/create", sendMsg);
            return JsonConvert.DeserializeObject<ChannelRoleCreate>(msg.data.ToString());
        }

        /// <summary>
        /// 更新频道角色权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelRoleUpdate ChannelRoleUpdate(ChannelRoleUpdateSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel-role/update", "/v3/channel-role/update", sendMsg);
            return JsonConvert.DeserializeObject<ChannelRoleUpdate>(msg.data.ToString());
        }

        /// <summary>
        /// 同步频道角色权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelRoleSync ChannelRoleSync(ChannelRoleSyncSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            BaseReturnMsg msg = SpeedLimiterHelper.CheckSpeedLimiter("channel-role/update", "/v3/channel-role/update", sendMsg);
            return JsonConvert.DeserializeObject<ChannelRoleSync>(msg.data.ToString());
        }

        /// <summary>
        /// 删除频道角色权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg ChannelRoleDelete(ChannelRoleDeleteSendMsg msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData, setting);
            return SpeedLimiterHelper.CheckSpeedLimiter("channel-role/delete", "/v3/channel-role/delete", sendMsg);
        }
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
