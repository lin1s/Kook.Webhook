using Command;
using Models.Response;

namespace Models.Event
{
    public class Funcs
    {
        Hook.Event.Entity entityEvents;

        public void Init()
        {
            entityEvents = new Hook.Event.Entity();

            entityEvents.PinnedMessageEvent += StartRailCommand.TestEvent;
        }

        public async Task Distribute(Challenge commandJson)
        {
            if (entityEvents == null)
                Init();

            var eventValue = commandJson.d.extra.Value<Models.Emun.Event>("type");

            switch (eventValue)
            {
                #region 频道相关事件列表

                case Models.Emun.Event.added_reaction:
                    entityEvents.AddedReaction(commandJson);
                    break;
                case Models.Emun.Event.deleted_reaction:
                    entityEvents.DeletedReaction(commandJson);
                    break;
                case Models.Emun.Event.updated_message:
                    entityEvents.UpdatedMessage(commandJson);
                    break;
                case Models.Emun.Event.deleted_message:
                    entityEvents.DeletedMessage(commandJson);
                    break;
                case Models.Emun.Event.added_channel:
                    entityEvents.AddedChannel(commandJson);
                    break;
                case Models.Emun.Event.updated_channel:
                    entityEvents.UpdatedChannel(commandJson);
                    break;
                case Models.Emun.Event.deleted_channel:
                    entityEvents.DeletedChannel(commandJson);
                    break;
                case Models.Emun.Event.pinned_message:
                    entityEvents.PinnedMessage(commandJson);
                    break;
                case Models.Emun.Event.unpinned_message:
                    entityEvents.UnpinnedMessage(commandJson);
                    break;

                #endregion

                #region 私聊消息事件

                case Models.Emun.Event.updated_private_message:
                    entityEvents.UpdatedPrivateMessage(commandJson);
                    break;
                case Models.Emun.Event.deleted_private_message:
                    entityEvents.DeletedPrivateMessage(commandJson);
                    break;
                case Models.Emun.Event.private_added_reaction:
                    entityEvents.PrivateAddedReaction(commandJson);
                    break;
                case Models.Emun.Event.private_deleted_reaction:
                    entityEvents.PrivateDeletedReaction(commandJson);
                    break;

                #endregion

                #region 服务器成员相关事件

                case Models.Emun.Event.joined_guild:
                    entityEvents.JoinedGuild(commandJson);
                    break;
                case Models.Emun.Event.exited_guild:
                    entityEvents.ExitedGuild(commandJson);
                    break;
                case Models.Emun.Event.updated_guild_member:
                    entityEvents.UpdatedGuildMember(commandJson);
                    break;
                case Models.Emun.Event.guild_member_online:
                    entityEvents.GuildMemberOnline(commandJson);
                    break;
                case Models.Emun.Event.guild_member_offline:
                    entityEvents.GuildMemberOffline(commandJson);
                    break;

                #endregion

                #region 服务器角色相关事件

                case Models.Emun.Event.added_role:
                    entityEvents.AddedRole(commandJson);
                    break;
                case Models.Emun.Event.deleted_role:
                    entityEvents.DeletedRole(commandJson);
                    break;
                case Models.Emun.Event.updated_role:
                    entityEvents.UpdatedRole(commandJson);
                    break;

                #endregion

                #region 服务器角色相关事件

                case Models.Emun.Event.updated_guild:
                    entityEvents.UpdatedGuild(commandJson);
                    break;
                case Models.Emun.Event.deleted_guild:
                    entityEvents.DeletedGuild(commandJson);
                    break;
                case Models.Emun.Event.added_block_list:
                    entityEvents.AddedBlockList(commandJson);
                    break;
                case Models.Emun.Event.deleted_block_list:
                    entityEvents.DeletedBlockList(commandJson);
                    break;
                case Models.Emun.Event.added_emoji:
                    entityEvents.AddedEmoji(commandJson);
                    break;
                case Models.Emun.Event.removed_emoji:
                    entityEvents.RemovedEmoji(commandJson);
                    break;
                case Models.Emun.Event.updated_emoji:
                    entityEvents.UpdatedEmoji(commandJson);
                    break;

                #endregion

                #region 服务器角色相关事件

                case Models.Emun.Event.joined_channel:
                    entityEvents.JoinedChannel(commandJson);
                    break;
                case Models.Emun.Event.exited_channel:
                    entityEvents.ExitedChannel(commandJson);
                    break;
                case Models.Emun.Event.user_updated:
                    entityEvents.UserUpdated(commandJson);
                    break;
                case Models.Emun.Event.self_joined_guild:
                    entityEvents.SelfJoinedGuild(commandJson);
                    break;
                case Models.Emun.Event.self_exited_guild:
                    entityEvents.SelfExitedGuild(commandJson);
                    break;
                case Models.Emun.Event.message_btn_click:
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
