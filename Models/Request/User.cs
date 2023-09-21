using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    /// <summary>
    /// 获取目标用户信息
    /// </summary>
    public class UserViewSendMsg
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public string user_id { get; set; }

        /// <summary>
        /// 服务器 id
        /// </summary>
        public string? guild_id { get; set; }
    }
}
