namespace Models.Json
{
    public class LimiterModel
    {
        public int Limit { get; set; }

        public int Remaining { get; set; }

        public int Reset { get; set; }

        public int Bucket { get; set; }
    }
}
