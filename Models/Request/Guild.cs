using Models.Emun;
using System.ComponentModel.DataAnnotations;

namespace Models.Request.Guild
{
    public class GuildListSendMsg
    {
        public string Page { get; set; }

        public string PageSize { get; set; }

        public SortType? SortType { get; set; }

        public GuildListSortField? SortField { get; set; }
    }

    public class GuildViewSendMsg
    {
        [Required]
        public string GuildID { get; set; }
    }
}
