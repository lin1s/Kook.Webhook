using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class GuildRole
    {
        /// <summary>
        /// 获取服务器角色列表
        /// </summary>
        public class GuildRoleListSendMsg
        {
            /// <summary>
            /// 服务器 id
            /// </summary>
            [Required]
            public string guild_id { get; set; }

            /// <summary>
            /// 目标页数
            /// </summary>
            public int? page { get; set; }

            /// <summary>
            /// 每页数据数量
            /// </summary>
            public int? page_size { get; set; }
        }

        /// <summary>
        /// 创建服务器角色
        /// </summary>
        public class GuildRoleCreateSendMsg
        {
            /// <summary>
            /// 如果不写，则为"新角色"
            /// </summary>
            public string? name { get; set; }

            /// <summary>
            /// 服务器 id
            /// </summary>
            [Required]
            public string guild_id { get; set; }
        }

        /// <summary>
        /// 更新服务器角色
        /// </summary>
        public class GuildRoleUpdateSendMsg
        {
            /// <summary>
            /// 服务器 id
            /// </summary>
            [Required]
            public string guild_id { get; set; }

            /// <summary>
            /// 角色 id
            /// </summary>
            [Required]
            public uint role_id { get; set; }

            /// <summary>
            /// 角色名称
            /// </summary>
            public string? name { get; set; }

            /// <summary>
            /// 颜色
            /// </summary>
            public uint? color { get; set; }

            /// <summary>
            /// 只能为 0 或者 1，是否把该角色的用户在用户列表排到前面
            /// </summary>
            public uint? hoist { get; set; }

            /// <summary>
            /// 只能为 0 或者 1，该角色是否可以被提及
            /// </summary>
            public uint? mentionable { get; set; }

            /// <summary>
            /// 权限
            /// </summary>
            public uint? permissions { get; set; }
        }

        public class GuildRoleDeleteSendMsg
        {
            /// <summary>
            /// 服务器 id
            /// </summary>
            [Required]
            public string guild_id { get; set; }

            /// <summary>
            /// 角色 id
            /// </summary>
            [Required]
            public uint role_id { get; set; }
        }

        /// <summary>
        /// 赋予用户角色
        /// </summary>
        public class GuildRoleGrantSendMsg
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
            /// 服务器角色 id
            /// </summary>
            [Required]
            public uint role_id { get; set; }
        }

        /// <summary>
        /// 删除用户角色
        /// </summary>
        public class GuildRoleRevoke
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
            /// 服务器角色 id
            /// </summary>
            [Required]
            public uint role_id { get; set; }
        }
    }
}
