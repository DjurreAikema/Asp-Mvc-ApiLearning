using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiLearning.Helpers;

namespace ApiLearning.Controllers
{
    public class InstagramController : Controller
    {
        private ApiInstagramHelper instagram = new ApiInstagramHelper();

        // GET: Instagram
        public ActionResult Feed()
        {
            var feed = instagram.GetFeed();

            return View(feed.data);
        }
    }
}