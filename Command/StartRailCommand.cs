using Command.Base;
using Json;
using Models.Attribute;
using Models.Emun;
using Models.Response;
using Models.Response.Guild;
using Newtonsoft.Json;
using Tools;

namespace Command
{
    public class StartRailCommand : BaseCommand
    {
        private readonly Config config = ConfigHelper.GetBaseConfig();
        private static Dictionary<string, SendMsgModel> picCache = new Dictionary<string, SendMsgModel>();

        [KookCommand("攻略", KeywordLocal.End)]
        public void GetData(Challenge commandJson)
        {
            if (commandJson.d.type != MessageType.Kmarkdown) return;
            string strContent = commandJson.d.content;

            string strCommand = strContent.Remove(strContent.IndexOf("攻略"), "攻略".Length).
                                           Remove(strContent.IndexOf(config.CommandPrefix), config.CommandPrefix.Length).Trim();

            if (picCache.Keys.Where(x => x == strCommand).Any())
            {
                KooKAPIHelpser.MessageCreate(picCache[strCommand]);
                return;
            }

            string strReturnMsg = HttpHelper.HttpGet("https://bbs-api.mihoyo.com/post/wapi/getPostFullInCollection?&gids=6&order_type=2&collection_id=1996095");
            StartRailData data = JsonConvert.DeserializeObject<StartRailData>(strReturnMsg);
            SendMsgModel sendMsgModel = new SendMsgModel();
            sendMsgModel.target_id = commandJson.d.target_id;
            sendMsgModel.type = MessageType.Text;
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

            HttpClient downloadClient = new HttpClient();
            Stream stream = downloadClient.GetStreamAsync(image.url).Result;

            sendMsgModel.content = KooKAPIHelpser.AssetCreate(stream).data.url;
            sendMsgModel.type = MessageType.Pic;
            picCache.Add(strCommand, sendMsgModel);
            KooKAPIHelpser.MessageCreate(sendMsgModel);
        }

        [KookCommand("测试", KeywordLocal.Contain)]
        public void TestApi(Challenge commandJson)
        {
            BaseReturnMsg a = KooKAPIHelpser.GuildList();
            GuildList item = JsonConvert.DeserializeObject<GuildList>(a.data.ToString());
        }
    }
}
