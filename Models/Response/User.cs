namespace Models.Response
{
    /// <summary>
    /// 获取当前用户信息
    /// </summary>
    public class UserMe : UserDetail
    {
        /// <summary>
        /// 当前邀请注册的人数
        /// </summary>
        public int invited_count { get; set; }
    }

    /// <summary>
    /// 获取目标用户信息
    /// </summary>
    public class UserView : UserDetail
    {
        /// <summary>
        /// 加入服务器时间
        /// </summary>
        public int joined_at { get; set; }

        /// <summary>
        /// 活跃时间
        /// </summary>
        public int active_time { get; set; }
    }
}