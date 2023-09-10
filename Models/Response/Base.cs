using Newtonsoft.Json.Linq;

namespace Models.Response
{
    public class BaseReturnMsg
    {
        public int code { get; set; }

        public string message { get; set; }

        public JToken data { get; set; }

        public object c { get; set; }
    }

    /// <summary>
    /// 分页信息
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int page_total { get; set; }

        /// <summary>
        /// 每一页的数据
        /// </summary>
        public int page_size { get; set; }

        /// <summary>
        /// 总数据量
        /// </summary>
        public int total { get; set; }
    }

    /// <summary>
    /// 服务器详情
    /// </summary>
    public class GuildDetail
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

    public class Role
    {
        public int role_id { get; set; }

        public string name { get; set; }

        public int color { get; set; }

        public int position { get; set; }

        public int hoist { get; set; }

        public int mentionable { get; set; }

        public int permissions { get; set; }
    }

    public class Channel
    {
        public int id { get; set; }

        public string guild_id { get; set; }

        public string user_id { get; set; }

        public int parent_id { get; set; }

        public string name { get; set; }

        public string topic { get; set; }

        public int type { get; set; }

        public int level { get; set; }

        public int slow_mode { get; set; }

        public bool is_category { get; set; }
    }


    public class MsgReturnData
    {
        public Guid msg_id { get; set; }

        public string msg_timestamp { get; set; }

        public string nonce { get; set; }
    }


}
