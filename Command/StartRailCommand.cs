using Command.Base;
using Json;
using Models.Emun;
using Models.Request.Guild;
using Models.Response;
using Newtonsoft.Json;
using Services;
using Tools;
using static Models.Request.Message;

namespace Command
{
    public class StartRailCommand : BaseCommand
    {
        private readonly Config config = ConfigHelper.GetBaseConfig();
        private static Dictionary<string, MessageCreateSendMsg> picCache = new Dictionary<string, MessageCreateSendMsg>();
        private readonly IKookApiServices _services;

        public StartRailCommand(IKookApiServices services)
        {
            _services = services;
        }

        [KookCommand("攻略", KeywordLocal.End)]
        public void GetData(Challenge commandJson)
        {
            if (commandJson.d.type != MessageType.Kmarkdown) return;
            string strContent = commandJson.d.content;

            string strCommand = strContent.Remove(strContent.IndexOf("攻略"), "攻略".Length).
                                           Remove(strContent.IndexOf(config.CommandPrefix), config.CommandPrefix.Length).Trim();

            if (picCache.Keys.Where(x => x == strCommand).Any())
            {
                _services.MessageCreate(picCache[strCommand]);
                return;
            }

            string strReturnMsg = HttpHelper.HttpGet("https://bbs-api.mihoyo.com/post/wapi/getPostFullInCollection?&gids=6&order_type=2&collection_id=1996095");
            StartRailData data = JsonConvert.DeserializeObject<StartRailData>(strReturnMsg);
            MessageCreateSendMsg sendMsgModel = new MessageCreateSendMsg();
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

            sendMsgModel.content = _services.AssetCreate(stream).url;
            sendMsgModel.type = MessageType.Pic;
            picCache.Add(strCommand, sendMsgModel);
            _services.MessageCreate(sendMsgModel);
        }

        [KookCommand("测试", KeywordLocal.Contain)]
        public void TestApi(Challenge commandJson)
        {
            GuildUserListSendMsg guildUserListSendMsg = new GuildUserListSendMsg();
            guildUserListSendMsg.guild_id = "8788733604562195";
            GuildUserList item = _services.GuildUserList(guildUserListSendMsg);
        }
    }
}
