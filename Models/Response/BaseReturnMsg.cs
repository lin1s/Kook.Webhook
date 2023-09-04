using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace Models.Response
{
    public class BaseReturnMsg
    {
        public int code { get; set; }

        public string message { get; set; }

        public JToken data { get; set; }
    }



    public class MsgReturnData
    {
        public Guid msg_id { get; set; }

        public string msg_timestamp { get; set; }

        public string nonce { get; set; }
    }


}
