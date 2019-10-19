using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ApiLearning.Helpers;

namespace ApiLearning.Controllers
{
    public class TwitterController : Controller
    {
        // Initialize an instance of the ApiTwitterHelper class to use 
        private ApiTwitterHelper twitter = new ApiTwitterHelper();

        // GET: Get the timeline of the selected used
        public ActionResult UserTimeline()
        {
            string[] parameters = { "screen_name=BarackObama", "tweet_mode=extended" };
            var timeLineTweets = twitter.GetUserTimeline(parameters);

            return View(timeLineTweets);
        }

        // Get: Get the user info of the selected user
        public ActionResult UserInfo()
        {
            string[] parameters = { "screen_name=BarackObama" };
            var userInfo = twitter.GetUserInfo(parameters);

            return View(userInfo);
        }
    }
}