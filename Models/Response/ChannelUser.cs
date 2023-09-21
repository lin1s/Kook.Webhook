namespace Models.Response
{
    /// <summary>
    /// 根据用户 id 和服务器 id 获取用户所在语音频道
    /// </summary>
    public class ChannelUserGetJoinedChannel
    {
        /// <summary>
        /// 频道列表
        /// </summary>
        public List<ChannelDetail> items { get; set; }

        /// <summary>
        /// 分页详情
        /// </summary>
        public Meta meta { get; set; }
    }
}