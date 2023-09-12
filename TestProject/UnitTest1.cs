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
            string strDecrypt = "{\r\n  \"id\": \"1c4532f6-*********-93e9-6347f410f91c\",\r\n  \"type\": 1,\r\n  \"content\": \"hello world\",\r\n  \"create_at\": 1628069285358,\r\n  \"author\": {\r\n    \"id\": \"308****000\",\r\n    \"username\": \"¸Ç Â×\",\r\n    \"identify_num\": \"**10\",\r\n    \"online\": true,\r\n    \"os\": \"Websocket\",\r\n    \"status\": 1,\r\n    \"avatar\": \"https://xxx.jpg/icon\",\r\n    \"vip_avatar\": \"\",\r\n    \"nickname\": \"***11377\",\r\n    \"roles\": [\r\n      102,\r\n      816\r\n    ],\r\n    \"is_vip\": false,\r\n    \"bot\": false,\r\n    \"mobile_verified\": true,\r\n    \"joined_at\": 1573816459000,\r\n    \"active_time\": 1628229821490\r\n  }\r\n}";
            var a = JsonConvert.DeserializeObject<Quote>(strDecrypt);

            //BaseReturnMsg b = new BaseReturnMsg();
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