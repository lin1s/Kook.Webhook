using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class DirectMessage
    {
        /// <summary>
        /// 获取私信聊天消息列表
        /// </summary>
        public class DirectMessageListSendMsg
        {
            /// <summary>
            /// 消息列表
            /// </summary>
            public List<MessageDetail> items { get; set; }
        }

        /// <summary>
        /// 获取私信聊天消息详情
        /// </summary>
        public class DirectMessageView : MessageDetail { }

        /// <summary>
        /// 发送私信聊天消息
        /// </summary>
        public class DirectMessageCreate
        {
            /// <summary>
            /// 服务端生成的消息 id
            /// </summary>
            public string msg_id { get; set; }

            /// <summary>
            /// 消息发送时间(服务器时间戳)
            /// </summary>
            public long msg_timestamp { get; set; }

            /// <summary>
            /// 随机字符串
            /// </summary>
            public string nonce { get; set; }
        }

    }
}
