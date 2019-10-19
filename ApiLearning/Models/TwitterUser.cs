namespace ApiLearning.Models
{
    public class TwitterUser
    {
        public string Name { get; set; }
        public string Screen_name { get; set; }
        public bool Verified { get; set; }
        public string Profile_image_url_https { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Profile_banner_url { get; set; }
        public int Followers_count { get; set; }
        public int Friends_count { get; set; }
    }
}