
namespace Models.Response
{

    /// <summary>
    /// 当前用户加入的服务器列表
    /// </summary>
    public class GuildList
    {
        /// <summary>
        /// 服务器列表
        /// </summary>
        public List<GuildDetail> items { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>
        public Meta meta { get; set; }
    }

    /// <summary>
    /// 服务器详情
    /// </summary>
    public class GuildView : GuildDetail
    {
        /// <summary>
        /// 规则列表
        /// </summary>
        public List<RoleDetail> roles { get; set; }

        /// <summary>
        /// 频道列表
        /// </summary>
        public List<ChannelDetail> channels { get; set; }
    }

    /// <summary>
    /// 服务器中的用户列表
    /// </summary>
    public class GuildUserList
    {
        /// <summary>
        /// 用户数量
        /// </summary>
        public int user_count { get; set; }

        /// <summary>
        /// 在线用户数量
        /// </summary>
        public int online_count { get; set; }

        /// <summary>
        /// 离线用户数量
        /// </summary>
        public int offline_count { get; set; }

        /// <summary>
        /// 用户列表
        /// </summary>
        public List<UserDetail> items { get; set; }

        /// <summary>
        /// 分页信息
        /// </summary>

        public Meta meta { get; set; }
    }

    public class GuildMuteList
    {
        public Mute mic { get; set; }

        public Mute headset { get; set; }
    }

    public class Mute
    {
        public int type { get; set; }

        public List<string> user_ids { get; set; }
    }

    public class GuildBoostHistroy
    {
        public string user_id { get; set; }

        public string guild_id { get; set; }

        public long start_time { get; set; }

        public long end_time { get; set; }

        public UserDetail user { get; set; }
    }
}
