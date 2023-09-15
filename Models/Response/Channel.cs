namespace Models.Response
{
    public class Channel
    {
        /// <summary>
        /// 获取频道列表
        /// </summary>
        public class ChannelList
        {
            /// <summary>
            /// 频道详情列表
            /// </summary>
            public List<ChannelDetail> items { get; set; }

            /// <summary>
            /// 分页信息
            /// </summary>
            public Meta meta { get; set; }
        }

        /// <summary>
        /// 获取频道详情
        /// </summary>
        public class ChannelView : ChannelDetail
        {
            /// <summary>
            /// 语音频道质量级别，1 流畅，2 正常，3 高质量
            /// </summary>
            public string voice_quality { get; set; }

            /// <summary>
            /// 语音服务器地址，HOST:PORT/PATH的格式
            /// </summary>
            public string server_url { get; set; }

            /// <summary>
            /// 子频道的id列表
            /// </summary>
            public List<string> children { get; set; }
        }

        /// <summary>
        /// 创建频道
        /// </summary>
        public class ChannelCreate : ChannelView
        {

        }

        /// <summary>
        /// 编辑频道
        /// </summary>
        public class ChannelUpdate : ChannelDetail
        {

        }

        /// <summary>
        /// 语音频道用户列表
        /// </summary>
        public class ChannelUserList : UserDetail
        {

        }

        /// <summary>
        /// 频道角色权限详情
        /// </summary>
        public class ChannelRoleIndex
        {
            /// <summary>
            /// 频道权限覆写的角色列表, role_id 为角色 id, 其它字段见下表
            /// </summary>
            public List<PermissionOverwrites> permission_overwrites { get; set; }

            /// <summary>
            /// 频道权限覆写的用户列表, user 字段参见用户接口, 其它的见下表
            /// </summary>
            public List<PermissionUsers> permission_users { get; set; }

            /// <summary>
            /// 是否同步分组的权限
            /// </summary>
            public int permission_sync { get; set; }
        }

        /// <summary>
        /// 创建频道角色权限
        /// </summary>
        public class ChannelRoleCreate
        {
            public object user_id { get; set; }

            public object role_id { get; set; }

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
        /// 更新频道角色权限
        /// </summary>
        public class ChannelRoleUpdate
        {
            public object user_id { get; set; }

            public object role_id { get; set; }

            /// <summary>
            /// 最终修改成功后，允许的权限的结果集
            /// </summary>
            public int allow { get; set; }

            /// <summary>
            /// 最终修改成功后，拒绝的权限的结果集
            /// </summary>
            public int deny { get; set; }

        }

        public class ChannelRoleSync
        {
            /// <summary>
            /// 针对角色在该频道的权限覆写规则组成的列表
            /// </summary>
            public List<PermissionOverwrites> permission_overwrites { get; set; }

            /// <summary>
            /// 针对用户在该频道的权限覆写规则组成的列表
            /// </summary>
            public List<PermissionUsers> permission_users { get; set; }
        }
    }
}
