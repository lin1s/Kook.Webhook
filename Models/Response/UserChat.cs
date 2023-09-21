namespace Models.Response
{
    public class UserChatList
    {
        /// <summary>
        /// 私聊列表
        /// </summary>
        public List<UserChatDetail> items { get; set; }

        /// <summary>
        /// 分页详情
        /// </summary>
        public Meta meta { get; set; }
    }

    /// <summary>
    /// 获取私信聊天会话详情
    /// </summary>
    public class UserChatView : UserChatDetail { }

    /// <summary>
    /// 创建私信聊天会话
    /// </summary>
    public class UserChatCreate : UserChatDetail { }
}