
namespace Models.Response
{
    #region guild/list

    public class GuildList
    {
        public List<GuildDetail> items { get; set; }

        public Meta meta { get; set; }
    }

    public class GuildView : GuildDetail
    {
        public List<Role> roles { get; set; }

        public List<Channel> channels { get; set; }
    }


    #endregion 
}
