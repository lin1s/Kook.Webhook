using Models.Emun;
using System.ComponentModel.DataAnnotations;

namespace Models.Request.Guild
{
    public class GuildListSendMsg
    {
        /// <summary>
        /// 目标页数
        /// </summary>
        public string? Page { get; set; }

        /// <summary>
        /// 每页数据数量
        /// </summary>
        public string? PageSize { get; set; }

        /// <summary>
        /// 排序的类型
        /// </summary>
        public SortType? SortType { get; set; }

        /// <summary>
        /// 排序的字段
        /// </summary>
        public GuildListSortField? SortField { get; set; }
    }

    public class GuildViewSendMsg
    {
        /// <summary>
        /// 服务器 id
        /// </summary>
        [Required]
        public string GuildID { get; set; }
    }

    public class GuildUserListSendMsg
    {
        /// <summary>
        /// 服务器 id
        /// </summary>
        [Required]
        public string guild_id { get; set; }

        /// <summary>
        /// 频道 id
        /// </summary>
        public string? channel_id { get; set; }

        /// <summary>
        /// 搜索关键字，在用户名或昵称中搜索
        /// </summary>
        public string? search { get; set; }

        /// <summary>
        /// 角色 ID，获取特定角色的用户列表
        /// </summary>
        public int? role_id { get; set; }

        /// <summary>
        /// 只能为0或1，0是未认证，1是已认证
        /// </summary>
        public int? mobile_verified { get; set; }

        /// <summary>
        /// 根据活跃时间排序，0是顺序排列，1是倒序排列
        /// </summary>
        public int? active_time { get; set; }

        /// <summary>
        /// 根据加入时间排序，0是顺序排列，1是倒序排列
        /// </summary>
        public int? joined_at { get; set; }

        /// <summary>
        /// 目标页数
        /// </summary>
        public int? page { get; set; }

        /// <summary>
        /// 每页数据数量
        /// </summary>
        public int? page_size { get; set; }

        /// <summary>
        /// 获取指定 id 所属用户的信息
        /// </summary>
        public int? filter_user_id { get; set; }
    }

    public class GuildNickNameSendMsg
    {
        /// <summary>
        /// 服务器的 ID
        /// </summary>
        [Required]
        public string guild_id { get; set; }

        /// <summary>
        /// 昵称，2 - 64 长度，不传则清空昵称
        /// </summary>
        public string? nickname { get; set; }

        /// <summary>
        /// 要修改昵称的目标用户 ID，不传则修改当前登陆用户的昵称
        /// </summary>
        public string? user_id { get; set; }
    }

    public class GuildLeaveSendMsg
    {
        /// <summary>
        /// 服务器 id
        /// </summary>
        [Required]
        public string guild_id { get; set; }
    }

    public class GuildKickOutSendMsg
    {
        /// <summary>
        /// 服务器 ID
        /// </summary>
        [Required]
        public string guild_id { get; set; }

        /// <summary>
        /// 目标用户 ID
        /// </summary>
        [Required]
        public string target_id { get; set; }
    }

    public class GuildMuteListSendMsg
    {
        /// <summary>
        /// 服务器 id
        /// </summary>
        [Required]
        public string guild_id { get; set; }

        /// <summary>
        /// 返回格式，建议为"detail", 其他情况仅作为兼容
        /// </summary>
        public string return_type { get; set; } = "detail";
    }

    public class GuildMuteCreateSendMsg
    {
        /// <summary>
        /// 服务器 id
        /// </summary>
        [Required]
        public string guild_id { get; set; }

        /// <summary>
        /// 目标用户 id
        /// </summary>
        [Required]
        public string user_id { get; set; }

        /// <summary>
        /// 静音类型，1代表麦克风闭麦，2代表耳机静音
        /// </summary>
        [Required]
        public int type { get; set; }
    }

    public class GuildMuteDeleteSendMsg
    {
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

        /// <summary>
        /// 静音类型，1代表麦克风闭麦，2代表耳机静音
        /// </summary>
        [Required]
        public int type { get; set; }
    }

    public class GuildBoostHistorySendMsg
    {
        /// <summary>
        /// 服务器 id
        /// </summary>
        [Required]
        public string guild_id { get; set; }

        /// <summary>
        /// unix 时间戳，时间范围的开始时间
        /// </summary>
        public long start_time { get; set; }

        /// <summary>
        /// unix 时间戳，时间范围的结束时间
        /// </summary>
        public long end_time { get; set; }
    }
}
