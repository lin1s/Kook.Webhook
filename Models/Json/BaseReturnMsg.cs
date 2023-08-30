namespace Models.Json
{
    public class BaseReturnMsg
    {
        public int code { get; set; }

        public string message { get; set; }

        public BaseReturnData data { get; set; }
    }

    public class BaseReturnData
    {
        public Guid msg_id { get; set; }

        public string msg_timestamp { get; set; }

        public string nonce { get; set; }

        //public JsonObject not_permissions_mention { get; set; }
    }
}
