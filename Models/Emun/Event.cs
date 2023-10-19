using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Emun
{
    public enum Event
    {
        #region 频道相关事件列表

        /// <summary>
        /// 频道内用户添加 reaction
        /// </summary>
        added_reaction,

        /// <summary>
        /// 频道内用户取消 reaction
        /// </summary>
        deleted_reaction,

        /// <summary>
        /// 频道消息更新
        /// </summary>
        updated_message,

        /// <summary>
        /// 频道消息被删除
        /// </summary>
        deleted_message,

        /// <summary>
        /// 新增频道
        /// </summary>
        added_channel,

        /// <summary>
        /// 修改频道信息
        /// </summary>
        updated_channel,

        /// <summary>
        /// 删除频道
        /// </summary>
        deleted_channel,

        /// <summary>
        /// 新的频道置顶消息
        /// </summary>
        pinned_message,

        /// <summary>
        /// 取消频道置顶消息
        /// </summary>
        unpinned_message,

        #endregion

        #region 私聊消息事件

        /// <summary>
        /// 私聊消息更新
        /// </summary>
        updated_private_message,

        /// <summary>
        /// 私聊消息被删除
        /// </summary>
        deleted_private_message,

        /// <summary>
        /// 私聊内用户添加 reaction
        /// </summary>
        private_added_reaction,

        /// <summary>
        /// 私聊内用户取消 reaction
        /// </summary>
        private_deleted_reaction,

        #endregion

        #region 服务器成员相关事件

        /// <summary>
        /// 新成员加入服务器
        /// </summary>
        joined_guild,

        /// <summary>
        /// 服务器成员退出
        /// </summary>
        exited_guild,

        /// <summary>
        /// 服务器成员信息更新
        /// </summary>
        updated_guild_member,

        /// <summary>
        /// 服务器成员上线
        /// </summary>
        guild_member_online,

        /// <summary>
        /// 服务器成员下线
        /// </summary>
        guild_member_offline,

        #endregion

        #region 服务器角色相关事件

        /// <summary>
        /// 服务器角色增加
        /// </summary>
        added_role,

        /// <summary>
        /// 服务器角色删除
        /// </summary>
        deleted_role,

        /// <summary>
        /// 服务器角色更新
        /// </summary>
        updated_role,

        #endregion

        #region 服务器相关事件

        /// <summary>
        /// 服务器信息更新
        /// </summary>
        updated_guild,

        /// <summary>
        /// 服务器删除
        /// </summary>
        deleted_guild,

        /// <summary>
        /// 服务器封禁用户
        /// </summary>
        added_block_list,

        /// <summary>
        /// 服务器取消封禁用户
        /// </summary>
        deleted_block_list,

        /// <summary>
        /// 服务器添加新表情
        /// </summary>
        added_emoji,

        /// <summary>
        /// 服务器删除表情
        /// </summary>
        removed_emoji,

        /// <summary>
        /// 服务器更新表情
        /// </summary>
        updated_emoji,

        #endregion

        #region 用户相关事件列表

        /// <summary>
        /// 用户加入语音频道
        /// </summary>
        joined_channel,

        /// <summary>
        /// 用户退出语音频道
        /// </summary>
        exited_channel,

        /// <summary>
        /// 用户信息更新
        /// </summary>
        user_updated,

        /// <summary>
        /// 自己新加入服务器
        /// </summary>
        self_joined_guild,

        /// <summary>
        /// 自己退出服务器
        /// </summary>
        self_exited_guild,

        /// <summary>
        /// Card 消息中的 Button 点击事件
        /// </summary>
        message_btn_click
        #endregion
    }
}
