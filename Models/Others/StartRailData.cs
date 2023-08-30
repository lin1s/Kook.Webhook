namespace Json
{
    public class StartRailData
    {
        public string retcode { get; set; }

        public string message { get; set; }

        public Posts data { get; set; }

    }

    public class Posts
    {
        public List<Guide> posts { get; set; }

    }

    public class Guide
    {
        public Post post { get; set; }

        public List<ImageList> image_list { get; set; }
    }

    public class Post
    {
        public string subject { get; set; }
    }

    public class ImageList
    {
        public string url { get; set; }

        public int height { get; set; }
    }

}
