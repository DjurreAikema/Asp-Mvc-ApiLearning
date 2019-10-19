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
        public UserInfo User { get; set; }
    }
}