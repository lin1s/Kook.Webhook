﻿using Json;
using Models.Emun;
using Models.Json;
using Models.Request.Guild;
using Models.Response;
using Newtonsoft.Json;
using System.Reflection;
using Tools;

namespace Services
{
    public class KookApiServices : IKookApiServices
    {
        #region Guild

        public BaseReturnMsg GuildList(GuildListSendMsg msgData = null)
        {
            string data = "";
            if (msgData != null)
            {
                if (!string.IsNullOrEmpty(msgData.Page)) data += "&page=" + msgData.Page;
                if (!string.IsNullOrEmpty(msgData.PageSize)) data += "&page_size=" + msgData.PageSize;
                if (msgData.SortType != null && msgData.SortField != null)
                {
                    string sort = "";
                    if (msgData.SortType == SortType.Descending)
                    {
                        sort = "-";
                    }
                    sort += msgData.SortField;
                    data += "&sort=" + sort;
                }
            }
            string url = "/v3/guild/list";
            if (!string.IsNullOrEmpty(data))
                url += "?" + data.Remove(0, 1);

            return SpeedLimiterHelper.CheckSpeedLimiter("guild/list", url);
        }

        public BaseReturnMsg GuildView(GuildViewSendMsg msgData)
        {
            return SpeedLimiterHelper.CheckSpeedLimiter("guild/list", "/v3/guild/view?guild_id=" + msgData.GuildID);
        }

        public BaseReturnMsg GuildUserList(GuildUserListSendMsg msgData)
        {
            string data = "";

            Type type = msgData.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                var objValue = prop.GetValue(msgData);
                if (objValue != null)
                {
                    data += "&" + prop.Name + "=" + objValue;
                }
            }
            string url = "/v3/guild/user-list";
            if (!string.IsNullOrEmpty(data))
                url += "?" + data.Remove(0, 1);

            return SpeedLimiterHelper.CheckSpeedLimiter("guild/user-list", url);
        }

        //public BaseReturnMsg GuildNickName()
        //{

        //}
        #endregion

        #region AssetCreate  

        public AssetReturnMsg AssetCreate(Stream file)
        {
            Dictionary<string, Stream> postFile = new Dictionary<string, Stream>();
            postFile.Add("file", file);
            return SpeedLimiterHelper.CheckSpeedLimiter("asset/create", "/v3/asset/create", new Dictionary<string, string>(), postFile);

        }

        #endregion

        #region Message

        public BaseReturnMsg MessageCreate(SendMsgModel msgData)
        {
            string sendMsg = JsonConvert.SerializeObject(msgData);
            return SpeedLimiterHelper.CheckSpeedLimiter("message/create", "/v3/message/create", sendMsg);
        }

        #endregion

    }
}
