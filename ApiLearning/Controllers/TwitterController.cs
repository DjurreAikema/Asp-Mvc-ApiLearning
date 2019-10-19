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
        // GET: UserTimeline
        public ActionResult UserTimeline()
        {
            ApiTwitterHelper twitter = new ApiTwitterHelper();

            string[] parameters = { "screen_name=BarackObama", "tweet_mode=extended" };
            var timeLineTweets = twitter.GetUserTimeline(parameters);

            return View(timeLineTweets);
        }
    }
}