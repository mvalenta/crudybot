using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudyBot.Controllers
{
    public partial class DemoController : Controller
    {
        // GET: Demo
        public virtual ActionResult Index()
        {
            var secret = "";
            var embedUrl = "https://webchat.botframework.com/embed/" +
                ConfigurationManager.AppSettings["AppId"] + "?s=" +
                secret;
            if (secret != "")
            {
                ViewBag.URL = embedUrl;
            }
            return View();
        }
    }
}