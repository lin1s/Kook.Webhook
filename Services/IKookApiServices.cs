using Json;
using Models.Json;
using Models.Request.Guild;
using Models.Response;

namespace Services
{
    public interface IKookApiServices
    {
        #region Guild

        public BaseReturnMsg GuildList(GuildListSendMsg msgData = null);

        public BaseReturnMsg GuildView(GuildViewSendMsg msgData);

        #endregion

        #region AssetCreate

        public AssetReturnMsg AssetCreate(Stream file);

        #endregion

        #region Message

        public BaseReturnMsg MessageCreate(SendMsgModel msgData);

        #endregion

    }
}
