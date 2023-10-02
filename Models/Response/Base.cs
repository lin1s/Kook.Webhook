using Models.Emun;
using Newtonsoft.Json.Linq;

namespace Models.Response
{
    public class BaseReturnMsg
    {
        public int code { get; set; }

        public string message { get; set; }

        public dynamic data { get; set; }
    }

    /// <summary>
    /// 用户
    /// </summary>
    public class UserDetail
    {
        /// <summary>
        /// 用户的 id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 用户的名称
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 用户在当前服务器的昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 用户名的认证数字，用户名正常为：user_name#identify_num
        /// </summary>
        public string identify_num { get; set; }

        /// <summary>
        /// 当前是否在线
        /// </summary>
        public string online { get; set; }

        /// <summary>
        /// 是否为机器人
        /// </summary>
        public bool bot { get; set; }

        /// <summary>
        /// 用户的状态, 0 和 1 代表正常，10 代表被封禁
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 用户的头像的 url 地址
        /// </summary>
        public string avatar { get; set; }

        /// <summary>
        /// vip 用户的头像的 url 地址，可能为 gif 动图
        /// </summary>
        public string vip_avatar { get; set; }

        /// <summary>
        /// 是否手机号已验证
        /// </summary>
        public bool mobile_verified { get; set; }

        /// <summary>
        /// 手机区号,如中国为 86
        /// </summary>
        public string mobile_prefix { get; set; }

        /// <summary>
        /// 用户手机号，带掩码
        /// </summary>
        public int mobile { get; set; }

        /// <summary>
        /// 用户在当前服务器中的角色 id 组成的列表
        /// </summary>
        public List<int> roles { get; set; }
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

    /// <summary>
    /// 角色
    /// </summary>
    public class RoleDetail
    {
        /// <summary>
        /// 角色 id
        /// </summary>
        public uint role_id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 颜色色值
        /// </summary>
        public uint color { get; set; }

        /// <summary>
        /// 顺序位置
        /// </summary>
        public uint position { get; set; }

        /// <summary>
        /// 是否为角色设定(与普通成员分开显示)
        /// </summary>
        public int hoist { get; set; }

        /// <summary>
        /// 是否允许任何人@提及此角色
        /// </summary>
        public int mentionable { get; set; }

        /// <summary>
        /// 权限码
        /// </summary>
        public int permissions { get; set; }
    }

    /// <summary>
    /// 频道
    /// </summary>
    public class ChannelDetail
    {
        /// <summary>
        /// 频道 id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 频道名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 创建者 id
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// 服务器 id
        /// </summary>
        public string guild_id { get; set; }

        /// <summary>
        /// 频道简介
        /// </summary>
        public string topic { get; set; }

        /// <summary>
        /// 是否为分组，事件中为 int 格式
        /// </summary>
        public bool is_category { get; set; }

        /// <summary>
        /// 上级分组的 id (若没有则为 0 或空字符串)
        /// </summary>
        public int parent_id { get; set; }

        /// <summary>
        /// 排序 level
        /// </summary>
        public int level { get; set; }

        /// <summary>
        /// 慢速模式下限制发言的最短时间间隔, 单位为秒(s)
        /// </summary>
        public int slow_mode { get; set; }

        /// <summary>
        /// 频道类型: 1 文字频道, 2 语音频道
        /// </summary>
        public int type { get; set; }

        public List<PermissionOverwrites> permission_overwrites { get; set; }

        public List<PermissionUsers> permission_users { get; set; }

        /// <summary>
        /// 权限设置是否与分组同步, 1 or 0
        /// </summary>
        public int permission_sync { get; set; }

        /// <summary>
        /// 是否有密码
        /// </summary>
        public bool has_password { get; set; }
    }

    /// <summary>
    /// 引用消息
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// 引用消息 id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 引用消息类型
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 引用消息内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 引用消息创建时间（毫秒）
        /// </summary>
        public long create_at { get; set; }

        /// <summary>
        /// 作者的用户信息
        /// </summary>
        public UserDetail author { get; set; }
    }

    /// <summary>
    /// 附加的多媒体数据
    /// </summary>
    public class Attachments
    {
        /// <summary>
        /// 多媒体类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 多媒体地址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 多媒体名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 大小 单位 Byte
        /// </summary>
        public long size { get; set; }
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

    public class MsgReturnData
    {
        public Guid msg_id { get; set; }

        public string msg_timestamp { get; set; }

        public string nonce { get; set; }
    }

    public class PermissionOverwrites
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public int role_id { get; set; }

        /// <summary>
        /// 最终修改成功后，允许的权限的结果集
        /// </summary>
        public int allow { get; set; }

        /// <summary>
        /// 最终修改成功后，拒绝的权限的结果集
        /// </summary>
        public int deny { get; set; }
    }

    public class PermissionUsers
    {
        /// <summary>
        /// 用户详情
        /// </summary>
        public UserDetail user { get; set; }

        /// <summary>
        /// 最终修改成功后，允许的权限的结果集
        /// </summary>
        public int allow { get; set; }

        /// <summary>
        /// 最终修改成功后，拒绝的权限的结果集
        /// </summary>
        public int deny { get; set; }
    }

    /// <summary>
    /// 消息详情
    /// </summary>
    public class MessageDetail
    {
        /// <summary>
        /// 消息 id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType type { get; set; }

        /// <summary>
        /// 作者的用户信息
        /// </summary>
        public UserDetail author { get; set; }

        /// <summary>
        /// 消息内容（为了保障消息正常发出，请不要超过 8000 字符）
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// @特定用户 的用户 ID 数组，与 mention_info 中的数据对应
        /// </summary>
        public List<string> mention { get; set; }

        /// <summary>
        /// 是否含有 @全体人员
        /// </summary>
        public bool mention_all { get; set; }

        /// <summary>
        /// @特定角色 的角色 ID 数组，与 mention_info 中的数据对应
        /// </summary>
        public List<string> mention_roles { get; set; }

        /// <summary>
        /// 是否含有 @在线人员
        /// </summary>
        public bool mention_here { get; set; }

        /// <summary>
        /// 超链接解析数据
        /// </summary>
        public List<JToken> embeds { get; set; }

        /// <summary>
        /// 附加的多媒体数据
        /// </summary>
        public Attachments attachments { get; set; }

        /// <summary>
        /// 回应数据
        /// </summary>
        public List<JToken> reactions { get; set; }

        /// <summary>
        /// 引用消息
        /// </summary>
        public List<Quote> quote { get; set; }

        /// <summary>
        /// 引用特定用户或特定角色的信息
        /// </summary>
        public JToken mention_info { get; set; }
    }

    /// <summary>
    /// 私聊详情
    /// </summary>
    public class UserChatDetail
    {
        /// <summary>
        /// 私信会话 Code
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 上次阅读消息的时间 (毫秒)
        /// </summary>
        public int last_read_time { get; set; }

        /// <summary>
        /// 最新消息时间 (毫秒)
        /// </summary>
        public int lastst_msg_time { get; set; }

        /// <summary>
        /// 未读消息数
        /// </summary>
        public int unread_count { get; set; }

        /// <summary>
        /// 目标用户信息
        /// </summary>
        public UserDetail target_info { get; set; }
    }
}
