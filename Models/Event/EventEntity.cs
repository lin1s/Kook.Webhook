using Models.Response;

namespace Models.Event
{
    public class EventEntity
    {
        #region 频道相关事件列表

        #region 频道内用户添加 reaction

        public event EventHandler<Challenge> AddedReactionEvent;

        public void AddedReaction(Challenge commandJson)
        {
            if (AddedReactionEvent != null)
                AddedReactionEvent(this, commandJson);
        }

        #endregion

        # region 频道内用户取消 reaction

        public event EventHandler<Challenge> DeletedReactionEvent;

        public void DeletedReaction(Challenge commandJson)
        {
            if (DeletedReactionEvent != null)
                DeletedReactionEvent(this, commandJson);
        }

        #endregion

        #region 频道消息更新

        public event EventHandler<Challenge> UpdatedMessageEvent;

        public void UpdatedMessage(Challenge commandJson)
        {
            if (UpdatedMessageEvent != null)
                UpdatedMessageEvent(this, commandJson);
        }

        #endregion

        #region 频道消息被删除

        public event EventHandler<Challenge> DeletedMessageEvent;

        public void DeletedMessage(Challenge commandJson)
        {
            if (DeletedMessageEvent != null)
                DeletedMessageEvent(this, commandJson);
        }

        #endregion

        #region 新增频道

        public event EventHandler<Challenge> AddedChannelEvent;

        public void AddedChannel(Challenge commandJson)
        {
            if (AddedChannelEvent != null)
                AddedChannelEvent(this, commandJson);
        }

        #endregion

        #region 修改频道信息

        public event EventHandler<Challenge> UpdatedChannelEvent;

        public void UpdatedChannel(Challenge commandJson)
        {
            if (UpdatedChannelEvent != null)
                UpdatedChannelEvent(this, commandJson);
        }

        #endregion

        #region 删除频道

        public event EventHandler<Challenge> DeletedChannelEvent;

        public void DeletedChannel(Challenge commandJson)
        {
            if (DeletedChannelEvent != null)
                DeletedChannelEvent(this, commandJson);
        }

        #endregion

        #region 新的频道置顶消息

        public event EventHandler<Challenge> PinnedMessageEvent;

        public void PinnedMessage(Challenge commandJson)
        {
            if (PinnedMessageEvent != null)
                PinnedMessageEvent(this, commandJson);
        }

        #endregion

        #region 取消频道置顶消息

        public event EventHandler<Challenge> UnpinnedMessageEvent;

        public void UnpinnedMessage(Challenge commandJson)
        {
            if (UnpinnedMessageEvent != null)
                UnpinnedMessageEvent(this, commandJson);
        }

        #endregion

        #endregion

        #region 私聊消息事件

        #region 私聊消息更新

        public event EventHandler<Challenge> UpdatedPrivateMessageEvent;

        public void UpdatedPrivateMessage(Challenge commandJson)
        {
            if (UpdatedPrivateMessageEvent != null)
                UpdatedPrivateMessageEvent(this, commandJson);
        }

        #endregion

        # region 私聊消息被删除

        public event EventHandler<Challenge> DeletedPrivateMessageEvent;

        public void DeletedPrivateMessage(Challenge commandJson)
        {
            if (DeletedPrivateMessageEvent != null)
                DeletedPrivateMessageEvent(this, commandJson);
        }

        #endregion

        #region 私聊内用户添加 reaction

        public event EventHandler<Challenge> PrivateAddedReactionEvent;

        public void PrivateAddedReaction(Challenge commandJson)
        {
            if (PrivateAddedReactionEvent != null)
                PrivateAddedReactionEvent(this, commandJson);
        }

        #endregion

        #region 私聊内用户取消 reaction

        public event EventHandler<Challenge> PrivateDeletedReactionEvent;

        public void PrivateDeletedReaction(Challenge commandJson)
        {
            if (PrivateDeletedReactionEvent != null)
                PrivateDeletedReactionEvent(this, commandJson);
        }

        #endregion

        #endregion

        #region 服务器成员相关事件

        #region 新成员加入服务器

        public event EventHandler<Challenge> JoinedGuildEvent;

        public void JoinedGuild(Challenge commandJson)
        {
            if (JoinedGuildEvent != null)
                JoinedGuildEvent(this, commandJson);
        }

        #endregion

        # region 服务器成员退出

        public event EventHandler<Challenge> ExitedGuildEvent;

        public void ExitedGuild(Challenge commandJson)
        {
            if (ExitedGuildEvent != null)
                ExitedGuildEvent(this, commandJson);
        }

        #endregion

        #region 服务器成员信息更新

        public event EventHandler<Challenge> UpdatedGuildMemberEvent;

        public void UpdatedGuildMember(Challenge commandJson)
        {
            if (UpdatedGuildMemberEvent != null)
                UpdatedGuildMemberEvent(this, commandJson);
        }

        #endregion

        #region 服务器成员上线

        public event EventHandler<Challenge> GuildMemberOnlineEvent;

        public void GuildMemberOnline(Challenge commandJson)
        {
            if (GuildMemberOnlineEvent != null)
                GuildMemberOnlineEvent(this, commandJson);
        }

        #endregion

        #region 服务器成员下线

        public event EventHandler<Challenge> GuildMemberOfflineEvent;

        public void GuildMemberOffline(Challenge commandJson)
        {
            if (GuildMemberOfflineEvent != null)
                GuildMemberOfflineEvent(this, commandJson);
        }

        #endregion

        #endregion

        #region 服务器角色相关事件

        #region 服务器角色增加

        public event EventHandler<Challenge> AddedRoleEvent;

        public void AddedRole(Challenge commandJson)
        {
            if (UpdatedRoleEvent != null)
                AddedRoleEvent(this, commandJson);
        }

        #endregion

        #region 服务器角色删除

        public event EventHandler<Challenge> DeletedRoleEvent;

        public void DeletedRole(Challenge commandJson)
        {
            if (DeletedRoleEvent != null)
                DeletedRoleEvent(this, commandJson);
        }

        #endregion

        #region 服务器角色更新

        public event EventHandler<Challenge> UpdatedRoleEvent;

        public void UpdatedRole(Challenge commandJson)
        {
            if (UpdatedRoleEvent != null)
                UpdatedRoleEvent(this, commandJson);
        }

        #endregion

        #endregion

        #region 服务器相关事件

        #region 服务器信息更新

        public event EventHandler<Challenge> UpdatedGuildEvent;

        public void UpdatedGuild(Challenge commandJson)
        {
            if (UpdatedGuildEvent != null)
                UpdatedGuildEvent(this, commandJson);
        }

        #endregion

        #region 服务器删除

        public event EventHandler<Challenge> DeletedGuildEvent;

        public void DeletedGuild(Challenge commandJson)
        {
            if (DeletedGuildEvent != null)
                DeletedGuildEvent(this, commandJson);
        }

        #endregion

        #region 服务器封禁用户

        public event EventHandler<Challenge> AddedBlockListEvent;

        public void AddedBlockList(Challenge commandJson)
        {
            if (AddedBlockListEvent != null)
                AddedBlockListEvent(this, commandJson);
        }

        #endregion

        #region 服务器取消封禁用户

        public event EventHandler<Challenge> DeletedBlockListEvent;

        public void DeletedBlockList(Challenge commandJson)
        {
            if (DeletedBlockListEvent != null)
                DeletedBlockListEvent(this, commandJson);
        }

        #endregion

        #region 服务器添加新表情

        public event EventHandler<Challenge> AddedEmojiEvent;

        public void AddedEmoji(Challenge commandJson)
        {
            if (AddedEmojiEvent != null)
                AddedEmojiEvent(this, commandJson);
        }

        #endregion

        #region 服务器删除表情

        public event EventHandler<Challenge> RemovedEmojiEvent;

        public void RemovedEmoji(Challenge commandJson)
        {
            if (RemovedEmojiEvent != null)
                RemovedEmojiEvent(this, commandJson);
        }

        #endregion

        #region 服务器更新表情

        public event EventHandler<Challenge> UpdatedEmojiEvent;

        public void UpdatedEmoji(Challenge commandJson)
        {
            if (UpdatedEmojiEvent != null)
                UpdatedEmojiEvent(this, commandJson);
        }

        #endregion

        #endregion

        #region 用户相关事件列表

        #region 用户加入语音频道

        public event EventHandler<Challenge> JoinedChannelEvent;

        public void JoinedChannel(Challenge commandJson)
        {
            if (JoinedChannelEvent != null)
                JoinedChannelEvent(this, commandJson);
        }

        #endregion

        #region 用户退出语音频道

        public event EventHandler<Challenge> ExitedChannelEvent;

        public void ExitedChannel(Challenge commandJson)
        {
            if (ExitedChannelEvent != null)
                ExitedChannelEvent(this, commandJson);
        }

        #endregion

        #region 用户信息更新

        public event EventHandler<Challenge> UserUpdatedEvent;

        public void UserUpdated(Challenge commandJson)
        {
            if (UserUpdatedEvent != null)
                UserUpdatedEvent(this, commandJson);
        }

        #endregion

        #region 自己新加入服务器

        public event EventHandler<Challenge> SelfJoinedGuildEvent;

        public void SelfJoinedGuild(Challenge commandJson)
        {
            if (SelfJoinedGuildEvent != null)
                SelfJoinedGuildEvent(this, commandJson);
        }

        #endregion

        #region 自己退出服务器

        public event EventHandler<Challenge> SelfExitedGuildEvent;

        public void SelfExitedGuild(Challenge commandJson)
        {
            if (SelfExitedGuildEvent != null)
                AddedEmojiEvent(this, commandJson);
        }

        #endregion

        #region Card 消息中的 Button 点击事件

        public event EventHandler<Challenge> MessageBtnClickEvent;

        public void MessageBtnClick(Challenge commandJson)
        {
            if (MessageBtnClickEvent != null)
                MessageBtnClickEvent(this, commandJson);
        }

        #endregion

        #endregion
    }
}
