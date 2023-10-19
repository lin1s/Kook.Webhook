using Models.Response;

namespace Hook.Event
{
    public class Entity
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

        public event EventHandler<Challenge> PinnedMessageEvent;

        public void PinnedMessage(Challenge commandJson)
        {
            PinnedMessageEvent(this, commandJson);
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

        #region 服务器相关事件

        #region 服务器信息更新

        public event Action<Challenge> UpdatedGuildEvent;

        public void UpdatedGuild(Challenge commandJson)
        {
            UpdatedGuildEvent(commandJson);
        }

        #endregion

        #region 服务器删除

        public event Action<Challenge> DeletedGuildEvent;

        public void DeletedGuild(Challenge commandJson)
        {
            DeletedGuildEvent(commandJson);
        }

        #endregion

        #region 服务器封禁用户

        public event Action<Challenge> AddedBlockListEvent;

        public void AddedBlockList(Challenge commandJson)
        {
            AddedBlockListEvent(commandJson);
        }

        #endregion

        #region 服务器取消封禁用户

        public event Action<Challenge> DeletedBlockListEvent;

        public void DeletedBlockList(Challenge commandJson)
        {
            DeletedBlockListEvent(commandJson);
        }

        #endregion

        #region 服务器添加新表情

        public event Action<Challenge> AddedEmojiEvent;

        public void AddedEmoji(Challenge commandJson)
        {
            AddedEmojiEvent(commandJson);
        }

        #endregion

        #region 服务器删除表情

        public event Action<Challenge> RemovedEmojiEvent;

        public void RemovedEmoji(Challenge commandJson)
        {
            RemovedEmojiEvent(commandJson);
        }

        #endregion

        #region 服务器更新表情

        public event Action<Challenge> UpdatedEmojiEvent;

        public void UpdatedEmoji(Challenge commandJson)
        {
            UpdatedEmojiEvent(commandJson);
        }

        #endregion

        #endregion

        #region 用户相关事件列表

        #region 用户加入语音频道

        public event Action<Challenge> JoinedChannelEvent;

        public void JoinedChannel(Challenge commandJson)
        {
            JoinedChannelEvent(commandJson);
        }

        #endregion

        #region 用户退出语音频道

        public event Action<Challenge> ExitedChannelEvent;

        public void ExitedChannel(Challenge commandJson)
        {
            ExitedChannelEvent(commandJson);
        }

        #endregion

        #region 用户信息更新

        public event Action<Challenge> UserUpdatedEvent;

        public void UserUpdated(Challenge commandJson)
        {
            UserUpdatedEvent(commandJson);
        }

        #endregion

        #region 自己新加入服务器

        public event Action<Challenge> SelfJoinedGuildEvent;

        public void SelfJoinedGuild(Challenge commandJson)
        {
            SelfJoinedGuildEvent(commandJson);
        }

        #endregion

        #region 自己退出服务器

        public event Action<Challenge> SelfExitedGuildEvent;

        public void SelfExitedGuild(Challenge commandJson)
        {
            AddedEmojiEvent(commandJson);
        }

        #endregion

        #region Card 消息中的 Button 点击事件

        public event Action<Challenge> MessageBtnClickEvent;

        public void MessageBtnClick(Challenge commandJson)
        {
            MessageBtnClickEvent(commandJson);
        }

        #endregion

        #endregion
    }
}
