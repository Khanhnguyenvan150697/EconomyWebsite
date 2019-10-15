using Economy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Economy.Common.Admin;

namespace Economy.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Account()
        {
            ViewBag.Session = Session[Common.CommonConstant.USER_SESSION];
            return PartialView();
        }
        public ActionResult DisplayAdminName()
        {
            ViewBag.Session = Session[Common.Admin.CommonConstant.ADMIN_SESSION];
            return PartialView();
        }
    }
}