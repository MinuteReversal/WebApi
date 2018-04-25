using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult Form()
        {
            return View();
        }


        public ActionResult Upload()
        {
            //https://www.asp.net/web-api/overview/advanced/sending-html-form-data-part-2
            return View();
        }

        public ActionResult ServerSend()
        {
            return View();
        }

        public ActionResult DateTimeAndJSDate()
        {
            return View();
        }

        public ActionResult ValuesApi()
        {
            return View();
        }

        public ActionResult QueryStringModel()
        {
            return View();
        }
    }
}
