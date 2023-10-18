using Models.Response;

namespace Hook.Event
{
    public class EventClass
    {
        #region 频道相关事件列表

        #region 频道内用户添加 reaction

        public event Action<Challenge> AddedReactionEvent;

        public void AddedReaction(Challenge commandJson)
        {
            AddedReactionEvent(commandJson);
        }

        #endregion

        # region 频道内用户取消 reaction

        public event Action<Challenge> DeletedReactionEvent;

        public void DeletedReaction(Challenge commandJson)
        {
            DeletedReactionEvent(commandJson);
        }

        #endregion

        #region 频道消息更新

        public event Action<Challenge> UpdatedMessageEvent;

        public void UpdatedMessage(Challenge commandJson)
        {
            UpdatedMessageEvent(commandJson);
        }

        #endregion

        #region 频道消息被删除

        public event Action<Challenge> DeletedMessageEvent;

        public void DeletedMessage(Challenge commandJson)
        {
            DeletedMessageEvent(commandJson);
        }

        #endregion

        #region 新增频道

        public event Action<Challenge> AddedChannelEvent;

        public void AddedChannel(Challenge commandJson)
        {
            AddedChannelEvent(commandJson);
        }

        #endregion

        #region 修改频道信息

        public event Action<Challenge> UpdatedChannelEvent;

        public void UpdatedChannel(Challenge commandJson)
        {
            UpdatedChannelEvent(commandJson);
        }

        #endregion

        #region 删除频道

        public event Action<Challenge> DeletedChannelEvent;

        public void DeletedChannel(Challenge commandJson)
        {
            DeletedChannelEvent(commandJson);
        }

        #endregion

        #region 新的频道置顶消息

        public event Action<Challenge> PinnedMessageEvent;

        public void PinnedMessage(Challenge commandJson)
        {
            PinnedMessageEvent(commandJson);
        }

        #endregion

        #region 取消频道置顶消息

        public event Action<Challenge> UnpinnedMessageEvent;

        public void UnpinnedMessage(Challenge commandJson)
        {
            UnpinnedMessageEvent(commandJson);
        }

        #endregion

        #endregion

        #region 私聊消息事件

        #region 私聊消息更新

        public event Action<Challenge> UpdatedPrivateMessageEvent;

        public void UpdatedPrivateMessage(Challenge commandJson)
        {
            UpdatedPrivateMessageEvent(commandJson);
        }

        #endregion

        # region 私聊消息被删除

        public event Action<Challenge> DeletedPrivateMessageEvent;

        public void DeletedPrivateMessage(Challenge commandJson)
        {
            DeletedPrivateMessageEvent(commandJson);
        }

        #endregion

        #region 私聊内用户添加 reaction

        public event Action<Challenge> PrivateAddedReactionEvent;

        public void PrivateAddedReaction(Challenge commandJson)
        {
            PrivateAddedReactionEvent(commandJson);
        }

        #endregion

        #region 私聊内用户取消 reaction

        public event Action<Challenge> PrivateDeletedReactionEvent;

        public void PrivateDeletedReaction(Challenge commandJson)
        {
            PrivateDeletedReactionEvent(commandJson);
        }

        #endregion

        #endregion

        #region 服务器成员相关事件

        #region 新成员加入服务器

        public event Action<Challenge> JoinedGuildEvent;

        public void JoinedGuild(Challenge commandJson)
        {
            JoinedGuildEvent(commandJson);
        }

        #endregion

        # region 服务器成员退出

        public event Action<Challenge> ExitedGuildEvent;

        public void ExitedGuild(Challenge commandJson)
        {
            ExitedGuildEvent(commandJson);
        }

        #endregion

        #region 服务器成员信息更新

        public event Action<Challenge> UpdatedGuildMemberEvent;

        public void UpdatedGuildMember(Challenge commandJson)
        {
            UpdatedGuildMemberEvent(commandJson);
        }

        #endregion

        #region 服务器成员上线

        public event Action<Challenge> GuildMemberOnlineEvent;

        public void GuildMemberOnline(Challenge commandJson)
        {
            GuildMemberOnlineEvent(commandJson);
        }

        #endregion

        #region 服务器成员下线

        public event Action<Challenge> GuildMemberOfflineEvent;

        public void GuildMemberOffline(Challenge commandJson)
        {
            GuildMemberOfflineEvent(commandJson);
        }

        #endregion

        #endregion

        #region 服务器角色相关事件

        #region 服务器角色增加

        public event Action<Challenge> AddedRoleEvent;

        public void AddedRole(Challenge commandJson)
        {
            AddedRoleEvent(commandJson);
        }

        #endregion

        #region 服务器角色删除

        public event Action<Challenge> DeletedRoleEvent;

        public void DeletedRole(Challenge commandJson)
        {
            DeletedRoleEvent(commandJson);
        }

        #endregion

        #region 服务器角色更新

        public event Action<Challenge> UpdatedRoleEvent;

        public void UpdatedRole(Challenge commandJson)
        {
            UpdatedRoleEvent(commandJson);
        }

        #endregion

        #endregion
    }
}
