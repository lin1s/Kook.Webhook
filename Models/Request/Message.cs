using Models.Emun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class Message
    {
        /// <summary>
        /// 获取频道聊天消息列表
        /// </summary>
        public class MessageListSendMsg
        {
            /// <summary>
            /// 频道 id
            /// </summary>
            [Required]
            public string target_id { get; set; }

            /// <summary>
            /// 参考消息 id，不传则查询最新消息
            /// </summary>
            public string? msg_id { get; set; }

            /// <summary>
            /// 只能为 0 或者 1，是否查询置顶消息。 置顶消息只支持查询最新的消息
            /// </summary>
            public int? pin { get; set; }

            /// <summary>
            /// 查询模式，有三种模式可以选择。不传则默认查询最新的消息
            /// </summary>
            public MessageSearchFlag? flag { get; set; }
        }

        /// <summary>
        /// 获取频道聊天消息详情
        /// </summary>
        public class MessageViewSendMsg
        {
            /// <summary>
            /// 消息 id
            /// </summary>
            [Required]
            public string msg_id { get; set; }
        }

        /// <summary>
        /// 发送频道聊天消息
        /// </summary>
        public class MessageCreateSendMsg
        {
            /// <summary>
            /// 消息类型, 见[type], 不传默认为 1, 代表文本类型。 9 代表 kmarkdown 消息, 10 代表卡片消息。
            /// </summary>
            public MessageType type { get; set; } = MessageType.Text;

            /// <summary>
            /// 目标频道 id
            /// </summary>
            [Required]
            public string target_id { get; set; }

            /// <summary>
            /// 消息内容
            /// </summary>
            [Required]
            public string content { get; set; }

            /// <summary>
            /// 回复某条消息的 msgId
            /// </summary>
            public string? quote { get; set; }

            /// <summary>
            /// nonce, 服务端不做处理, 原样返回
            /// </summary>
            public string? nonce { get; set; }

            /// <summary>
            /// 用户 id,如果传了，代表该消息是临时消息，该消息不会存数据库，但是会在频道内只给该用户推送临时消息。用于在频道内针对用户的操作进行单独的回应通知等。
            /// </summary>
            public string? temp_target_id { get; set; }
        }

        /// <summary>
        /// 更新频道聊天消息
        /// </summary>
        public class MessageUpdateSendMsg
        {
            /// <summary>
            /// 消息 id
            /// </summary>
            [Required]
            public string msg_id { get; set; }

            /// <summary>
            /// 消息内容
            /// </summary>
            [Required]
            public string content { get; set; }

            /// <summary>
            /// 回复某条消息的 msgId。如果为空，则代表删除回复，不传则无影响。
            /// </summary>
            public string? quote { get; set; }

            /// <summary>
            /// 用户 id，针对特定用户临时更新消息，必须是正常消息才能更新。与发送临时消息概念不同，但同样不保存数据库。
            /// </summary>
            public string? temp_target_id { get; set; }
        }

        /// <summary>
        /// 删除频道聊天消息
        /// </summary>
        public class MessageDeleteSendMsg
        {
            /// <summary>
            /// 消息 id
            /// </summary>
            [Required]
            public string msg_id { get; set; }
        }

        /// <summary>
        /// 获取频道消息某回应的用户列表
        /// </summary>
        public class MessageReactionListSendMsg
        {
            /// <summary>
            /// 频道消息的 id
            /// </summary>
            [Required]
            public string msg_id { get; set; }

            /// <summary>
            /// emoji 的 id, 可以为 GuilEmoji 或者 Emoji, 注意：在 get 中，应该进行 urlencode
            /// </summary>
            [Required]
            public string emoji { get; set; }
        }

        public class MessageAddReactionSendMsg
        {
            /// <summary>
            /// 频道消息的 id
            /// </summary>
            [Required]
            public string msg_id { get; set; }

            /// <summary>
            /// emoji 的 id, 可以为 GuilEmoji 或者 Emoji, 注意：在 get 中，应该进行 urlencode
            /// </summary>
            [Required]
            public string emoji { get; set; }

        }

        public class MessageDeleteReaction
        {
            /// <summary>
            /// 频道消息的 id
            /// </summary>
            [Required]
            public string msg_id { get; set; }

            /// <summary>
            /// emoji 的 id, 可以为 GuilEmoji 或者 Emoji, 注意：在 get 中，应该进行 urlencode
            /// </summary>
            [Required]
            public string emoji { get; set; }

            public string? user_id { get; set; }
        }
    }
}
