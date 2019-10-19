using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiLearning.Models
{
    public class Tweet
    {
        public string Full_text { get; set; }
        public string Created_at { get; set; }
        public User User { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Screen_name { get; set; }
        public bool Verified { get; set; }
        public string Profile_image_url_https { get; set; }
    }
}