﻿using Models.Json;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;

namespace Tools
{
    public static class SpeedLimiterHelper
    {
        private static Config BaseConfig = ConfigHelper.GetBaseConfig();
        private static Dictionary<string, int> dicLimiter = new Dictionary<string, int>();

        private static Dictionary<string, string> header = new Dictionary<string, string>
        {
            { "Authorization", "Bot " + BaseConfig.Token }
        };

        public static BaseReturnMsg CheckSpeedLimiter(string bucket, string url, string postData)
        {
            if (dicLimiter.ContainsKey(bucket))
            {
                if (dicLimiter[bucket] < BaseConfig.Limit)
                    Task.Delay(1000);
            }

            string strMsg;
            HttpHeaders responseHeader;
            (strMsg, responseHeader) = HttpHelper.HttpPostWithHeader(BaseConfig.BaseUrl + url, postData, headers: header);

            BaseReturnMsg ReturnMsg = JsonConvert.DeserializeObject<BaseReturnMsg>(strMsg);

            if (ReturnMsg.code == 0)
            {
                string strbucket = responseHeader.GetValues("X-Rate-Limit-Bucket").First();
                int Remaining = Convert.ToInt32(responseHeader.GetValues("X-Rate-Limit-Remaining").First());

                if (dicLimiter.ContainsKey(bucket))
                {
                    dicLimiter[bucket] = Remaining;
                }
                else
                {
                    dicLimiter.Add(bucket, Remaining);
                }
            }
            else if (ReturnMsg.code == 429)
            {
                int Remaining = Convert.ToInt32(responseHeader.GetValues("X-Rate-Limit-Reset").First());
                Task.Delay(1000);
                return CheckSpeedLimiter(bucket, url, postData);
            }

            return ReturnMsg;
        }

        public static AssetReturnMsg CheckSpeedLimiter(string bucket, string url, Dictionary<string, string> postData, Dictionary<string, Stream> postFile)
        {
            if (dicLimiter.ContainsKey(bucket))
            {
                if (dicLimiter[bucket] < BaseConfig.Limit)
                    Task.Delay(1000);
            }

            string strMsg;
            HttpHeaders responseHeader;
            (strMsg, responseHeader) = HttpHelper.HttpPostWithHeader(BaseConfig.BaseUrl + url, postData, postFile, headers: header);

            AssetReturnMsg ReturnMsg = JsonConvert.DeserializeObject<AssetReturnMsg>(strMsg);

            if (ReturnMsg.code == 0)
            {
                string strbucket = responseHeader.GetValues("X-Rate-Limit-Bucket").First();
                int Remaining = Convert.ToInt32(responseHeader.GetValues("X-Rate-Limit-Remaining").First());

                if (dicLimiter.ContainsKey(bucket))
                {
                    dicLimiter[bucket] = Remaining;
                }
                else
                {
                    dicLimiter.Add(bucket, Remaining);
                }
            }
            else if (ReturnMsg.code == 429)
            {
                int Remaining = Convert.ToInt32(responseHeader.GetValues("X-Rate-Limit-Reset").First());
                Task.Delay(1000);
                return CheckSpeedLimiter(bucket, url, postData, postFile);
            }

            return ReturnMsg;
        }

    }
}