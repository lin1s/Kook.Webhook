using Models.Emun;
using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    /// <summary>
    /// 获取私信聊天消息列表
    /// </summary>
    public class DirectMessageListSendMsg
    {
        /// <summary>
        /// 私信会话 Code。chat_code与target_id必须传一个
        /// </summary>
        public string? chat_code { get; set; }

        /// <summary>
        /// 目标用户 id，后端会自动创建会话。有此参数之后可不传chat_code参数
        /// </summary>
        public string? target_id { get; set; }

        /// <summary>
        /// 参考消息 id，不传则查询最新消息
        /// </summary>
        public string? msg_id { get; set; }

        /// <summary>
        /// 查询模式，有三种模式可以选择。不传则默认查询最新的消息。
        /// </summary>
        public MessageSearchFlag? flag { get; set; }

        /// <summary>
        /// 目标页数
        /// </summary>
        public int? page { get; set; }

        /// <summary>
        /// 当前分页消息数量, 默认 50
        /// </summary>
        public int? page_size { get; set; }
    }

    /// <summary>
    /// 获取私信聊天消息详情
    /// </summary>
    public class DirectMessageViewSendMsg
    {
        /// <summary>
        /// 私信会话 Code
        /// </summary>
        [Required]
        public string chat_code { get; set; }

        /// <summary>
        /// 私聊消息 id
        /// </summary>
        [Required]
        public string msg_id { get; set; }
    }

    public class DirectMessageCreateSendMsg
    {
        /// <summary>
        /// 消息类型, 见[type], 不传默认为 1, 代表文本类型。 9 代表 kmarkdown 消息, 10 代表卡片消息。
        /// </summary>
        public MessageType type { get; set; } = MessageType.Text;

        /// <summary>
        /// 目标用户 id，后端会自动创建会话。有此参数之后可不传 chat_code参数
        /// </summary>
        public string? target_id { get; set; }

        /// <summary>
        /// 目标会话 Code，chat_code 与 target_id 必须传一个
        /// </summary>
        public string? chat_code { get; set; }

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
    }

    /// <summary>
    /// 更新私信聊天消息
    /// </summary>
    public class DirectMessageUpdateSendMsg
    {
        /// <summary>
        /// 消息 id
        /// </summary>
        public string? msg_id { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        [Required]
        public string content { get; set; }

        /// <summary>
        /// 回复某条消息的 msgId。如果为空，则代表删除回复，不传则无影响。
        /// </summary>
        public string? quote { get; set; }
    }

    /// <summary>
    /// 删除私信聊天消息
    /// </summary>
    public class DirectMessageDeleteSendMsg
    {
        /// <summary>
        /// 消息 id
        /// </summary>
        public string? msg_id { get; set; }
    }

    /// <summary>
    /// 获取频道消息某回应的用户列表
    /// </summary>
    public class DirectMessageReactionListSendMsg
    {
        /// <summary>
        /// 消息的 id
        /// </summary>
        [Required]
        public string msg_id { get; set; }

        /// <summary>
        /// emoji 的 id, 可以为 GuildEmoji 或者 Emoji, 注意：在 get 中，应该进行 urlencode
        /// </summary>
        public string? emoji { get; set; }
    }

    /// <summary>
    /// 给某个消息添加回应
    /// </summary>
    public class DirectMessageAddReactionSendMsg
    {
        /// <summary>
        /// 消息 id
        /// </summary>
        [Required]
        public string msg_id { get; set; }

        /// <summary>
        /// emoji 的 id, 可以为 GuilEmoji 或者 Emoji
        /// </summary>
        [Required]
        public string emoji { get; set; }
    }

    /// <summary>
    /// 删除消息的某个回应
    /// </summary>
    public class DirectMessageDeleteReactionSendMsg
    {
        [Required]
        public string msg_id { get; set; }

        /// <summary>
        /// 表情的 ID
        /// </summary>
        [Required]
        public string emoji { get; set; }

        /// <summary>
        /// 用户的 id, 如果不填则为自己的 id。删除别人的 reaction 需要有管理频道消息的权限
        /// </summary>
        public string? user_id { get; set; }
    }
}