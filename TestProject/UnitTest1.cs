using Command;
using Models.Response;
using Newtonsoft.Json;
using System.Reflection;
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
            string strDecrypt = "{\r\n    \"code\": 0,\r\n    \"message\": \"²Ù×÷³É¹¦\",\r\n    \"data\": [\r\n        {\r\n            \"id\": \"999999999\",\r\n            \"username\": \"XXX\",\r\n            \"identify_num\": \"9999\",\r\n            \"online\": true,\r\n            \"os\": \"Websocket\",\r\n            \"status\": 1,\r\n            \"avatar\": \"XXX\",\r\n            \"vip_avatar\": \"XXX\",\r\n            \"banner\": \"\",\r\n            \"nickname\": \"XXX\",\r\n            \"roles\": [\r\n                4131873\r\n            ],\r\n            \"is_vip\": false,\r\n            \"is_ai_reduce_noise\": true,\r\n            \"is_personal_card_bg\": false,\r\n            \"bot\": false,\r\n            \"mobile_verified\": true,\r\n            \"joined_at\": 1639808384000,\r\n            \"active_time\": 1639808384000,\r\n            \"live_info\": {\r\n                \"in_live\": false,\r\n                \"audience_count\": 0,\r\n                \"live_thumb\": \"\",\r\n                \"live_start_time\": 0\r\n            }\r\n        }\r\n    ]\r\n}";
            var a = JsonConvert.DeserializeObject<BaseReturnMsg>(strDecrypt);
            var b = JsonConvert.DeserializeObject<List<ChannelUserList>>(a.data.ToString());


            //ChannelListSendMsg b = new ChannelListSendMsg();
            //string c = JsonConvert.SerializeObject(b, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        [TestMethod]
        public void BinaryDataTest()
        {
            HttpClient client = new HttpClient();

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Authorization", "Bot 1/MjI1MTg=/kou6KxFQ0+49QHTbCDrZyg==");
        }

        [TestMethod]
        public void ReflectionTest()
        {
            ConstructorInfo[] properties = typeof(StartRailCommand).GetConstructors();

            var a = properties[0].GetParameters();

            foreach (var b in a)
            {
                Type t = b.ParameterType;
            }

        }
    }
}