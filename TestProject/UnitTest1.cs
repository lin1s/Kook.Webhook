using Command;
using Models.Request;
using Models.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            string strDecrypt = @"{
    ""code"": 0,
    ""message"": ""²Ù×÷³É¹¦"",
    ""data"": {
        {
            ""id"": ""xxxx"",
            ""username"": ""test"",
            ""identify_num"": ""xxx"",
            ""online"": false,
            ""status"": 0,
            ""avatar"": ""https://img.kaiheila.cn/avatars/2020-02/xxxx.jpg/icon"",
            ""vip_avatar"": ""https://img.kaiheila.cn/avatars/2020-02/xxxx.jpg/icon"",
            ""bot"": false,
            ""nickname"": ""xxxx"",
            ""reaction_time"": 1612323994414
        }
    }
}";

            var a = JsonConvert.DeserializeObject<Dictionary<string,object>>(strDecrypt);
            //var b = JsonConvert.DeserializeObject<DirectMessageReactionList>(a.data.ToString());
            
            JObject jobject =JObject.FromObject(strDecrypt);

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

