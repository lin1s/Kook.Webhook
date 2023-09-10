
namespace Models.Response
{
    #region guild/list

    /// <summary>
    /// 当前用户加入的服务器列表
    /// </summary>
    public class GuildList
    {
        public List<GuildDetail> items { get; set; }

        public Meta meta { get; set; }
    }

    /// <summary>
    /// 服务器详情
    /// </summary>
    public class GuildView : GuildDetail
    {
        public List<Role> roles { get; set; }

        public List<Channel> channels { get; set; }
    }

    /// <summary>
    /// 服务器中的用户列表
    /// </summary>
    public class GuildUserList
    {
        public Meta meta { get; set; }

        public int user_count { get; set; }

        public int online_count { get; set; }

        public int offline_count { get; set; }
    }

    #endregion 
}
