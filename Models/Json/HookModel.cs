﻿using Models.Emun;
using Newtonsoft.Json.Linq;

namespace Json
{
    public class Encryption
    {
        public string encrypt { get; set; }
    }

    public class Challenge
    {
        public int s { get; set; }

        public ChallengData d { get; set; }
    }

    public class ChallengData
    {
        public ChannelType channel_type { get; set; }

        public MessageType type { get; set; }

        public string target_id { get; set; }

        public string author_id { get; set; }

        public string content { get; set; }

        public string msg_id { get; set; }

        public long msg_timestamp { get; set; }

        public string nonce { get; set; }

        public JObject extra { get; set; }

        public string verify_token { get; set; }

        public string challenge { get; set; }
    }
}