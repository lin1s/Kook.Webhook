namespace Models.Json
{
    public class AssetReturnMsg
    {
        public string code { get; set; }

        public string message { get; set; }

        public AssetData data { get; set; }
    }

    public class AssetData
    {
        public string url { get; set; }
    }
}
