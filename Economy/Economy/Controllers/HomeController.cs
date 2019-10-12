using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Economy.Common;
using Economy.Models;

namespace Economy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Session = Session[CommonConstant.USER_SESSION];
            return View();
        }
    }
}