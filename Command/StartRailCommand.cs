using Json;
using Models.Attribute;
using Models.Emun;
using Models.Json;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using Tools;

namespace Command
{
    public class StartRailCommand
    {
        private readonly Config config = ConfigHelper.GetBaseConfig();

        [KookCommand("攻略")]
        [KeywordLocal(KeywordLocal.End)]
        public void GetData(Challenge commandJson)
        {
            if (commandJson.d.type != MessageType.Kmarkdown) return;
            string strContent = commandJson.d.content;

            string strCommand = strContent.Remove(strContent.IndexOf("攻略"), "攻略".Length).
                                           Remove(strContent.IndexOf(config.CommandPrefix), config.CommandPrefix.Length).Trim();

            string strReturnMsg = HttpHelper.HttpGet("https://bbs-api.mihoyo.com/post/wapi/getPostFullInCollection?&gids=6&order_type=2&collection_id=1996095");
            StartRailData data = JsonConvert.DeserializeObject<StartRailData>(strReturnMsg);
            SendMsgModel sendMsgModel = new SendMsgModel();
            sendMsgModel.target_id = commandJson.d.target_id;
            sendMsgModel.type = MessageType.Pic;
            if (data == null)
            {
                sendMsgModel.content = "接口网络出现问题，请稍后再试";
                return;
            }
            List<Guide> guides = data.data.posts;
            Guide guide = guides.Find(x => x.post.subject.Contains(strCommand));
            if (guide == null)
            {
                sendMsgModel.content = "当前角色攻略不存在，请稍后再试";
                return;
            }
            ImageList image = guide.image_list.MaxBy(x => x.height);

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Authorization", "Bot " + config.Token);

            HttpClient downloadClient = new HttpClient();
            Stream stream = downloadClient.GetStreamAsync(image.url).Result;
            Dictionary<string, Stream> postFile = new Dictionary<string, Stream>();
            postFile.Add("file", stream);
            string assetReturnMsg = HttpHelper.HttpPost(config.BaseUrl + "/v3/asset/create", postFile: postFile, headers: header);
            AssetReturnMsg assetMsg = JsonConvert.DeserializeObject<AssetReturnMsg>(assetReturnMsg);

            sendMsgModel.content = assetMsg.data.url;
            string sendMsg = JsonConvert.SerializeObject(sendMsgModel);
            string a = HttpHelper.HttpPost(config.BaseUrl + "/v3/message/create", sendMsg, headers: header);
        }


    }
}
