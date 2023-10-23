using Models.Emun;
using Models.Event;
using Models.Response;

namespace Command.Base
{
    public static partial class EventFunc
    {
        public static EventEntity Init()
        {
            EventEntity entityEvents = new EventEntity();

            entityEvents.PinnedMessageEvent += TestEvent;

            return entityEvents;
        }

        public static async Task Distribute(EventEntity entityEvents, Challenge commandJson)
        {
            if (entityEvents == null)
                return;

            string stringValue = commandJson.d.extra.Value<string>("type");
            Models.Emun.EventType eventValue = (EventType)Enum.Parse(typeof(EventType), stringValue);

            switch (eventValue)
            {
                #region 频道相关事件列表

                case Models.Emun.EventType.added_reaction:
                    entityEvents.AddedReaction(commandJson);
                    break;
                case Models.Emun.EventType.deleted_reaction:
                    entityEvents.DeletedReaction(commandJson);
                    break;
                case Models.Emun.EventType.updated_message:
                    entityEvents.UpdatedMessage(commandJson);
                    break;
                case Models.Emun.EventType.deleted_message:
                    entityEvents.DeletedMessage(commandJson);
                    break;
                case Models.Emun.EventType.added_channel:
                    entityEvents.AddedChannel(commandJson);
                    break;
                case Models.Emun.EventType.updated_channel:
                    entityEvents.UpdatedChannel(commandJson);
                    break;
                case Models.Emun.EventType.deleted_channel:
                    entityEvents.DeletedChannel(commandJson);
                    break;
                case Models.Emun.EventType.pinned_message:
                    entityEvents.PinnedMessage(commandJson);
                    break;
                case Models.Emun.EventType.unpinned_message:
                    entityEvents.UnpinnedMessage(commandJson);
                    break;

                #endregion

                #region 私聊消息事件

                case Models.Emun.EventType.updated_private_message:
                    entityEvents.UpdatedPrivateMessage(commandJson);
                    break;
                case Models.Emun.EventType.deleted_private_message:
                    entityEvents.DeletedPrivateMessage(commandJson);
                    break;
                case Models.Emun.EventType.private_added_reaction:
                    entityEvents.PrivateAddedReaction(commandJson);
                    break;
                case Models.Emun.EventType.private_deleted_reaction:
                    entityEvents.PrivateDeletedReaction(commandJson);
                    break;

                #endregion

                #region 服务器成员相关事件

                case Models.Emun.EventType.joined_guild:
                    entityEvents.JoinedGuild(commandJson);
                    break;
                case Models.Emun.EventType.exited_guild:
                    entityEvents.ExitedGuild(commandJson);
                    break;
                case Models.Emun.EventType.updated_guild_member:
                    entityEvents.UpdatedGuildMember(commandJson);
                    break;
                case Models.Emun.EventType.guild_member_online:
                    entityEvents.GuildMemberOnline(commandJson);
                    break;
                case Models.Emun.EventType.guild_member_offline:
                    entityEvents.GuildMemberOffline(commandJson);
                    break;

                #endregion

                #region 服务器角色相关事件

                case Models.Emun.EventType.added_role:
                    entityEvents.AddedRole(commandJson);
                    break;
                case Models.Emun.EventType.deleted_role:
                    entityEvents.DeletedRole(commandJson);
                    break;
                case Models.Emun.EventType.updated_role:
                    entityEvents.UpdatedRole(commandJson);
                    break;

                #endregion

                #region 服务器角色相关事件

                case Models.Emun.EventType.updated_guild:
                    entityEvents.UpdatedGuild(commandJson);
                    break;
                case Models.Emun.EventType.deleted_guild:
                    entityEvents.DeletedGuild(commandJson);
                    break;
                case Models.Emun.EventType.added_block_list:
                    entityEvents.AddedBlockList(commandJson);
                    break;
                case Models.Emun.EventType.deleted_block_list:
                    entityEvents.DeletedBlockList(commandJson);
                    break;
                case Models.Emun.EventType.added_emoji:
                    entityEvents.AddedEmoji(commandJson);
                    break;
                case Models.Emun.EventType.removed_emoji:
                    entityEvents.RemovedEmoji(commandJson);
                    break;
                case Models.Emun.EventType.updated_emoji:
                    entityEvents.UpdatedEmoji(commandJson);
                    break;

                #endregion

                #region 服务器角色相关事件

                case Models.Emun.EventType.joined_channel:
                    entityEvents.JoinedChannel(commandJson);
                    break;
                case Models.Emun.EventType.exited_channel:
                    entityEvents.ExitedChannel(commandJson);
                    break;
                case Models.Emun.EventType.user_updated:
                    entityEvents.UserUpdated(commandJson);
                    break;
                case Models.Emun.EventType.self_joined_guild:
                    entityEvents.SelfJoinedGuild(commandJson);
                    break;
                case Models.Emun.EventType.self_exited_guild:
                    entityEvents.SelfExitedGuild(commandJson);
                    break;
                case Models.Emun.EventType.message_btn_click:
                    entityEvents.MessageBtnClick(commandJson);
                    break;

                #endregion

                default:
                    break;
            }

            return;
        }
    }
}
