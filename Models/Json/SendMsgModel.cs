using Models.Emun;

namespace Json
{
    public class SendMsgModel
    {
        public MessageType type { get; set; } = MessageType.Text;

        public string target_id { get; set; }

        public string content { get; set; }

        public string quote { get; set; }

        public string nonce { get; set; }

        public string temp_target_id { get; set; }
    }
}
