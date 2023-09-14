using Models.Emun;
using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class Channel
    {
        /// <summary>
        /// 获取频道列表
        /// </summary>
        public class ChannelListSendMsg
        {
            /// <summary>
            /// 目标页数
            /// </summary>
            public int? page { get; set; }

            /// <summary>
            /// 每页数据数量
            /// </summary>
            public int? page_size { get; set; }

            /// <summary>
            /// 服务器 id
            /// </summary>
            [Required]
            public string guild_id { get; set; }

            /// <summary>
            /// 频道类型, 1为文字，2为语音, 默认为1
            /// </summary>
            public ChannelType type { get; set; } = ChannelType.Text;
        }

        /// <summary>
        /// 获取频道详情
        /// </summary>
        public class ChannelViewSendMsg
        {
            /// <summary>
            /// 频道 id
            /// </summary>
            [Required]
            public string target_id { get; set; }

            /// <summary>
            /// 是否需要获取子频道。true是 false否 默认为false
            /// </summary>
            public bool? need_children { get; set; }
        }

        /// <summary>
        /// 创建频道
        /// </summary>
        public class ChannelCreateSendMsg
        {
            /// <summary>
            /// 服务器 id
            /// </summary>
            [Required]
            public string guild_id { get; set; }

            /// <summary>
            /// 频道名称
            /// </summary>
            [Required]
            public string name { get; set; }

            /// <summary>
            /// 父分组 id
            /// </summary>
            public string? parent_id { get; set; }

            /// <summary>
            /// 频道类型，1 文字，2 语音，默认为 1
            /// </summary>
            public ChannelType type { get; set; } = ChannelType.Text;
        }

        /// <summary>
        /// 编辑频道
        /// </summary>
        public class ChannelUpdateSendMsg
        {
            /// <summary>
            /// 服务器中频道的 ID
            /// </summary>
            [Required]
            public string channel_id { get; set; }

            /// <summary>
            /// 频道名称
            /// </summary>
            public string? name { get; set; }

            /// <summary>
            /// 频道排序
            /// </summary>
            public int? level { get; set; }

            /// <summary>
            /// 分组频道 ID，设置为 0 为移出分组
            /// </summary>
            public string? parent_id { get; set; }

            /// <summary>
            /// 频道简介，文字频道有效
            /// </summary>
            public string? topic { get; set; }

            /// <summary>
            /// 慢速模式，单位 ms。目前只支持这些值：0, 5000, 10000, 15000, 30000, 60000, 120000, 300000, 600000, 900000, 1800000, 3600000, 7200000, 21600000，文字频道有效
            /// </summary>
            public int? slow_mode { get; set; }

            /// <summary>
            /// 此频道最大能容纳的用户数量，最大值 99，语音频道有效
            /// </summary>
            public int? limit_amount { get; set; }

            /// <summary>
            /// 声音质量，1 流畅，2 正常，3 高质量，语音频道有效
            /// </summary>
            public string? voice_quality { get; set; }

            /// <summary>
            /// 密码，语音频道有效
            /// </summary>
            public string? password { get; set; }
        }

        /// <summary>
        /// 删除频道
        /// </summary>
        public class ChannelDeleteSendMsg
        {
            /// <summary>
            /// 频道 id
            /// </summary>
            [Required]
            public string channel_id { get; set; }
        }

        /// <summary>
        /// 语音频道用户列表
        /// </summary>
        public class ChannelUserListSendMsg
        {
            /// <summary>
            /// 频道id
            /// </summary>
            [Required]
            public string channel_id { get; set; }
        }

        /// <summary>
        /// 语音频道之间移动用户
        /// </summary>
        public class ChannelMoveUserSendMsg
        {
            /// <summary>
            /// 目标频道 id, 需要是语音频道
            /// </summary>
            [Required]
            public string target_id { get; set; }

            /// <summary>
            /// 用户 id 的数组
            /// </summary>
            public List<string> user_ids { get; set; }
        }

        /// <summary>
        /// 频道角色权限详情
        /// </summary>
        public class ChannelRoleIndexSendMsg
        {
            /// <summary>
            /// 频道 id
            /// </summary>
            [Required]
            public string channel_id { get; set;}
        }

        public class ChannelRoleCreateSendMsg
        {
            /// <summary>
            /// 频道 id, 如果频道是分组的 id,会同步给所有 sync=1 的子频道
            /// </summary>
            [Required]
            public string channel_id { get; set; }

            /// <summary>
            /// value 的类型，只能为"role_id","user_id",不传则默认为"user_id"
            /// </summary>
            public string? type { get; set; } = "user_id";

            /// <summary>
            /// 根据 type 的值，为 用户 id 或 角色 id
            /// </summary>
            public string? value { get; set; }
        }

        public class ChannelRoleUpdateSendMsg
        {
            /// <summary>
            /// 频道 id, 如果频道是分组的 id,会同步给所有 sync=1 的子频道
            /// </summary>
            [Required]
            public string channel_id { get; set; }

            /// <summary>
            /// value 的类型，只能为"role_id","user_id",不传则默认为"user_id"
            /// </summary>
            public string? type { get; set; } = "user_id";

            /// <summary>
            /// 根据 type 的值，为用户 id 或角色 id
            /// </summary>
            public string? value { get; set; }

            /// <summary>
            /// 默认为 0,想要设置的允许的权限值
            /// </summary>
            public int? allow { get; set; } = 0;

            /// <summary>
            /// 默认为 0,想要设置的拒绝的权限值
            /// </summary>
            public int? deny { get; set; } = 0;
        }

        public class ChannelRoleSyncSendMsg
        {
            /// <summary>
            /// 频道 ID
            /// </summary>
            [Required]
            public string channel_id { get; set; }
        }

        public class ChannelRoleDeleteSendMsg
        {
            /// <summary>
            /// 频道 id, 如果频道是分组的 id,会同步给所有 sync=1 的子频道
            /// </summary>
            [Required]
            public string channel_id { get; set; }

            /// <summary>
            /// value 的类型，只能为"role_id","user_id",不传则默认为"user_id"
            /// </summary>
            public string? type { get; set; } = "user_id";

            /// <summary>
            /// 根据 type，为用户 id 或角色 id
            /// </summary>
            public string value { get; set; }
        }
    }
}
