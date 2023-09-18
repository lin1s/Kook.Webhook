using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class ChannelUser
    {
        /// <summary>
        /// 根据用户 id 和服务器 id 获取用户所在语音频道
        /// </summary>
        public class ChannelUserGetJoinedChannelSendMsg
        {
            /// <summary>
            /// 目标页数
            /// </summary>
            public int? page { get; set; }

            /// <summary>
            /// 每页数据数量
            /// </summary>
            public int? page_size { get; set; }

            /// <summary>
            /// 服务器 id
            /// </summary>
            [Required]
            public string guild_id { get; set; }

            /// <summary>
            /// 用户 id
            /// </summary>
            [Required]
            public string user_id { get; set; }
        }
    }
}
