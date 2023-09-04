using Json;
using Models.Response;
using Newtonsoft.Json;
using System;
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
            string strDecrypt = "{\r\n  \"items\": [\r\n    {\r\n      \"id\": \"8788733604562195\",\r\n      \"name\": \"test\",\r\n      \"topic\": \"\",\r\n      \"master_id\": \"2718816871\",\r\n      \"user_id\": \"2718816871\",\r\n      \"is_master\": false,\r\n      \"icon\": \"\",\r\n      \"notify_type\": 2,\r\n      \"region\": \"shenzhen\",\r\n      \"enable_open\": false,\r\n      \"open_id\": \"0\",\r\n      \"default_channel_id\": \"7916827130763003\",\r\n      \"welcome_channel_id\": \"4422906926570372\"\r\n    }\r\n  ],\r\n  \"meta\": {\r\n    \"page\": 1,\r\n    \"page_total\": 1,\r\n    \"page_size\": 100,\r\n    \"total\": 1\r\n  },\r\n  \"sort\": {}\r\n}\r\n";
            BaseReturnMsg a = JsonConvert.DeserializeObject<BaseReturnMsg>(strDecrypt);      
        }

        [TestMethod]
        public void BinaryDataTest()
        {
            HttpClient client = new HttpClient();

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Authorization", "Bot 1/MjI1MTg=/kou6KxFQ0+49QHTbCDrZyg==");
        }
    }
}