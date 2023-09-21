﻿using Models.Request;
using Models.Request.Guild;
using Models.Response;
using Newtonsoft.Json;
using System;
using Tools;

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
        public BaseReturnMsg GuildNickName(GuildNickNameSendMsg msgData);

        /// <summary>
        /// 离开服务器
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildLeave(GuildLeaveSendMsg msgData);

        /// <summary>
        /// 踢出服务器
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildKickout(GuildKickOutSendMsg msgData);

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
        public BaseReturnMsg GuildMuteCreate(GuildMuteCreateSendMsg msgData);

        /// <summary>
        /// 删除服务器静音或闭麦
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg GuildMuteDelete(GuildMuteDeleteSendMsg msgData);

        /// <summary>
        /// 服务器助力历史 需要有服务器管理权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public GuildBoostHistroy GuildBoostHistroy(GuildBoostHistorySendMsg msgData);
        #endregion

        #region Channel

        /// <summary>
        /// 获取频道列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelList ChannelList(ChannelListSendMsg msgData);

        /// <summary>
        /// 获取频道详情
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelView ChannelView(ChannelViewSendMsg msgData);

        /// <summary>
        /// 创建频道
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelCreate ChannelCreate(ChannelCreateSendMsg msgData);

        /// <summary>
        /// 编辑频道
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelUpdate ChannelUpdate(ChannelUpdateSendMsg msgData);

        /// <summary>
        /// 删除频道
        /// </summary>
        /// <param name="msgData"></param>
        public BaseReturnMsg ChannelDelete(ChannelDeleteSendMsg msgData);

        /// <summary>
        /// 语音频道用户列表
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public List<UserDetail> ChannelUserList(ChannelUserListSendMsg msgData);

        /// <summary>
        /// 语音频道之间移动用户
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg ChannelMoveUser(ChannelMoveUserSendMsg msgData);

        /// <summary>
        /// 频道角色权限详情
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelRoleIndex ChannelRoleIndex(ChannelRoleIndexSendMsg msgData);

        /// <summary>
        /// 创建频道角色权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelRoleCreate ChannelRoleCreate(ChannelRoleCreateSendMsg msgData);

        /// <summary>
        /// 更新频道角色权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelRoleUpdate ChannelRoleUpdate(ChannelRoleUpdateSendMsg msgData);

        /// <summary>
        /// 同步频道角色权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public ChannelRoleSync ChannelRoleSync(ChannelRoleSyncSendMsg msgData);

        /// <summary>
        /// 删除频道角色权限
        /// </summary>
        /// <param name="msgData"></param>
        /// <returns></returns>
        public BaseReturnMsg ChannelRoleDelete(ChannelRoleDeleteSendMsg msgData);
        #endregion

        #region AssetCreate

        public AssetCreate AssetCreate(Stream file);

        #endregion

        #region Message

        public BaseReturnMsg MessageCreate(MessageCreateSendMsg msgData);

        #endregion

    }
}
