using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class Message
    {
        /// <summary>
        /// 获取频道聊天消息列表
        /// </summary>
        public class MessageList
        {
            /// <summary>
            /// 消息列表
            /// </summary>
            public List<MessageDetail> items { get; set; }
        }

        /// <summary>
        /// 获取频道聊天消息详情
        /// </summary>
        public class MessageView : MessageDetail
        {
            /// <summary>
            /// 消息所属的频道id
            /// </summary>
            public string channel_id { get; set; }
        }

        /// <summary>
        /// 发送频道聊天消息
        /// </summary>
        public class MessageCreate
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

        public class MessageReactionList : UserDetail
        {

        }
    }
}
