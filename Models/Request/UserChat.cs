using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class UserChat
    {
        /// <summary>
        /// 获取私信聊天会话列表
        /// </summary>
        public class UserChatListSendMsg
        {
            /// <summary>
            /// 目标页数
            /// </summary>
            public int? page { get; set; }

            /// <summary>
            /// 每页数据数量
            /// </summary>
            public int? page_size { get; set; }
        }

        /// <summary>
        /// 获取私信聊天会话详情
        /// </summary>
        public class UserChatViewSendMsg
        {
            /// <summary>
            /// 私聊会话 Code
            /// </summary>
            [Required]
            public string chat_code { get; set; }
        }

        /// <summary>
        /// 创建私信聊天会话
        /// </summary>
        public class UserChatCreate
        {
            /// <summary>
            /// 目标用户 id
            /// </summary>
            [Required]
            public string target_id { get; set; }
        }

        /// <summary>
        /// 删除私信聊天会话
        /// </summary>
        public class UserChatDelete
        {
            /// <summary>
            /// 目标私信会话 Code
            /// </summary>
            [Required]
            public string chat_code { get; set; }
        }
    }
}
