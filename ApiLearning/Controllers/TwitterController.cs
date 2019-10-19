using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiLearning.Helpers;

namespace ApiLearning.Controllers
{
    public class TwitterController : Controller
    {
        // GET: Twitter
        public ActionResult Index()
        {
            ApiTwitterHelper twitter = new ApiTwitterHelper();

            string[] parameters = { "screen_name=BarackObama", "tweet_mode=extended" };
            var timeLineTweets = twitter.GetUserTimeline(parameters);

            foreach (var tweet in timeLineTweets)
            {
                Response.Write(tweet.Name);
            }
            Response.End();

            return View(timeLineTweets);
        }
    }
}