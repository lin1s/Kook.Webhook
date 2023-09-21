using Models.Request;
using Models.Request.Guild;
using Models.Response;

namespace Services
{
    public interface IKookApiServices
    {
        #region Guild

        /// <summary>
        /// 获取当前用户加入的服务器列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildList GuildList(GuildListSendMsg msgData);

        /// <summary>
        /// 获取服务器详情
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildView GuildView(GuildViewSendMsg msgData);

        /// <summary>
        /// 获取服务器中的用户列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildUserList GuildUserList(GuildUserListSendMsg msgData);

        /// <summary>
        /// 修改服务器中用户的昵称
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildNickName(GuildNickNameSendMsg msgData);

        /// <summary>
        /// 离开服务器
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildLeave(GuildLeaveSendMsg msgData);

        /// <summary>
        /// 踢出服务器
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildKickout(GuildKickOutSendMsg msgData);

        /// <summary>
        /// 服务器静音闭麦列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildMuteList GuildMuteList(GuildMuteListSendMsg msgData);

        /// <summary>
        /// 添加服务器静音或闭麦
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildMuteCreate(GuildMuteCreateSendMsg msgData);

        /// <summary>
        /// 删除服务器静音或闭麦
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public void GuildMuteDelete(GuildMuteDeleteSendMsg msgData);

        /// <summary>
        /// 服务器助力历史 需要有服务器管理权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildBoostHistroy GuildBoostHistroy(GuildBoostHistorySendMsg msgData);
        #endregion

        #region AssetCreate

        public AssetCreate AssetCreate(Stream file);

        #endregion

        #region Message

        public BaseReturnMsg MessageCreate(MessageCreateSendMsg msgData);

        #endregion

    }
}
