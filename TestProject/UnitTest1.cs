using Json;
using Newtonsoft.Json;
using Tools;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DecryptTest()
        {
            var json = Tool.Decrypt("OGU0NTZmZjM4MTY4OTI1ZTZBZlR3Q2M0eUF3Z2VjTkNLR1JEZXdGMjlKa3lkK2NLdTV3aHdhUDdIVThGTnhVc2V3VGxuMnNTSk90M0dRNzMyOWlhMllITzBOcVh3VFVuR0xEajVuNkIrSXlrZGY0RWdnRld0UER1T1hrMmZCSjhxeTJoakdxQ00zRzNzQjZ2SGwxTmZnNzVYT1F3R21ZTUxWSmNpM0tGdTB1YUFlT21ibmlzSUl5ZDNudz0=", "");
        }

        [TestMethod]
        public void JsonConvertTest()
        {

            string strDecrypt = "{\"s\":0,\"d\":{\"channel_type\":\"GROUP\",\"type\":9,\"target_id\":\"7916827130763003\",\"author_id\":\"2718816871\",\"content\":\"213132\",\"extra\":{\"type\":9,\"code\":\"\",\"guild_id\":\"8788733604562195\",\"guild_type\":0,\"channel_name\":\"\\u6587\\u5b57\\u9891\\u9053\",\"author\":{\"id\":\"2718816871\",\"username\":\"lin_1\",\"identify_num\":\"6134\",\"online\":true,\"os\":\"Websocket\",\"status\":1,\"avatar\":\"https:\\/\\/img.kookapp.cn\\/assets\\/avatar_7.jpg?x-oss-process=style\\/icon\",\"vip_avatar\":\"https:\\/\\/img.kookapp.cn\\/assets\\/avatar_7.jpg?x-oss-process=style\\/icon\",\"banner\":\"\",\"nickname\":\"lin_1\",\"roles\":[],\"is_vip\":false,\"vip_amp\":false,\"is_ai_reduce_noise\":true,\"is_personal_card_bg\":false,\"bot\":false,\"decorations_id_map\":{\"background\":10208},\"is_sys\":false},\"visible_only\":null,\"mention\":[],\"mention_all\":false,\"mention_roles\":[],\"mention_here\":false,\"nav_channels\":[],\"kmarkdown\":{\"raw_content\":\"213132\",\"mention_part\":[],\"mention_role_part\":[],\"channel_part\":[]},\"emoji\":[],\"last_msg_content\":\"lin_1\\uff1a213132\",\"send_msg_device\":1},\"msg_id\":\"09b1f575-c55b-4b4e-a7de-b1e421fb9faf\",\"msg_timestamp\":1692248568558,\"nonce\":\"psgeZMJeJ6R1RSnNTnJQCNB3\",\"from_type\":1,\"verify_token\":\"LqaWUcgDMtyLNglo\"},\"sn\":3}";
            Challenge data = JsonConvert.DeserializeObject<Challenge>(strDecrypt);
        }

        [TestMethod]
        public void BinaryDataTest()
        {
            HttpClient client = new HttpClient();

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Authorization", "Bot 1/MjI1MTg=/kou6KxFQ0+49QHTbCDrZyg==");

            //var stream = response.Content.ReadAsStreamAsync().Result;

            //Dictionary<string, Stream> postFile = new Dictionary<string, Stream>();
            //postFile.Add("file", stream);

            //string returnMsg = HttpHelper.HttpPost("https://www.kookapp.cn/api/v3/asset/create", postFile: postFile, headers: header);

            //HttpClient downloadClient = new();
            //Stream stream = await downloadClient.GetStreamAsync(
            //    "https://upload-bbs.miyoushe.com/upload/2023/08/15/159117584/dbc4a3e1f3719eb8c5b433a5510ac2f0_7838700432791001646.png");

            //HttpClient client = new();
            //HttpRequestMessage request = new(HttpMethod.Post, "https://www.kookapp.cn/api/v3/asset/create");
            //request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("Authorization", "Bot xxxxxxxxxxxxxxxx");
            //MultipartFormDataContent content = new();
            //content.Add(new StreamContent(stream), "file", "D:/OneDrive/Desktop/photos/8.19ÐÇ×ù¼Æ»®/Route.jpg");
            //request.Content = content;
            //HttpResponseMessage response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());

        }
    }
}