using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response.Guild
{
    #region guild/list

    public class GuildList
    {
        public List<GuildListItems> items { get; set; }

        public GuildListMeta meta { get; set; }
    }

    public class GuildListItems
    {
        /// <summary>
        /// 服务器 id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 服务器主题
        /// </summary>
        public string topic { get; set; }

        /// <summary>
        /// 服务器主的 id
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 服务器 icon 的地址
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 通知类型
        /// </summary>
        public int notify_type { get; set; }

        /// <summary>
        /// 服务器默认使用语音区域
        /// </summary>
        public string region { get; set; }

        /// <summary>
        /// 是否为公开服务器
        /// </summary>
        public string enable_open { get; set; }

        /// <summary>
        /// 公开服务器 id
        /// </summary>
        public string open_id { get; set; }

        /// <summary>
        /// 默认频道 id
        /// </summary>
        public string default_channel_id { get; set; }

        /// <summary>
        /// 欢迎频道 id
        /// </summary>
        public string welcome_channel_id { get; set; }

        /// <summary>
        /// 服务器助力数量
        /// </summary>
        public string boost_num { get; set; }

        /// <summary>
        /// 服务器等级
        /// </summary>
        public string level { get; set; }
    }

    public class GuildListMeta
    {
        public int page { get; set; }

        public int page_total { get; set; }

        public int page_size { get; set; }

        public int total { get; set; }
    }

    #endregion 
}
