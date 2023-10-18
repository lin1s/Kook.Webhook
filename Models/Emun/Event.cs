using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Emun
{
    public enum Event
    {
        /// <summary>
        /// 频道内用户添加 reaction
        /// </summary>
        added_reaction,
        /// <summary>
        /// 频道内用户取消 reaction
        /// </summary>
        deleted_reaction,
        /// <summary>
        /// 频道消息更新
        /// </summary>
        updated_message,
        /// <summary>
        /// 频道消息被删除
        /// </summary>
        deleted_message,
        /// <summary>
        /// 新增频道
        /// </summary>
        added_channel,
        /// <summary>
        /// 修改频道信息
        /// </summary>
        updated_channel,
        /// <summary>
        /// 删除频道
        /// </summary>
        deleted_channel,
        /// <summary>
        /// 新的频道置顶消息
        /// </summary>
        pinned_message,
        /// <summary>
        /// 取消频道置顶消息
        /// </summary>
        unpinned_message
    }
}
