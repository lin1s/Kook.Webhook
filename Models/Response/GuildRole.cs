namespace Models.Response
{
    public class GuildRole
    {
        /// <summary>
        /// 获取服务器角色列表
        /// </summary>
        public class GuildRoleList : RoleDetail { }

        /// <summary>
        /// 创建服务器角色
        /// </summary>
        public class GuildRoleCreate : RoleDetail { }

        /// <summary>
        /// 更新服务器角色
        /// </summary>
        public class GuildRoleUpdate : RoleDetail { }

        /// <summary>
        /// 赋予用户角色
        /// </summary>
        public class GuildRoleGrant
        {
            /// <summary>
            /// 用户 id
            /// </summary>
            public string user_id { get; set; }

            /// <summary>
            /// 服务器 id
            /// </summary>
            public string guild_id { get; set; }

            /// <summary>
            /// 角色 id 的列表
            /// </summary>
            public List<int> roles { get; set; }
        }

        /// <summary>
        /// 删除用户角色
        /// </summary>
        public class GuildRoleRevoke
        {
            /// <summary>
            /// 用户 id
            /// </summary>
            public string user_id { get; set; }

            /// <summary>
            /// 服务器 id
            /// </summary>
            public string guild_id { get; set; }

            /// <summary>
            /// 角色 id 的列表
            /// </summary>
            public List<int> roles { get; set; }
        }
    }
}
