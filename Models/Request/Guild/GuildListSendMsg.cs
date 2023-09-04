using Models.Emun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request.Guild
{
    public class GuildListSendMsg
    {
        public string page { get; set; }

        public string page_size { get; set; }

        public SortType? sort_type { get; set; }

        public GuildListSortField? sort_field { get; set; }
    }
}
