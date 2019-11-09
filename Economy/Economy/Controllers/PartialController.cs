using Economy.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Economy.Common.Admin;
using Model.EF;
using Economy.Models;
using System.Data.Entity;

namespace Economy.Controllers
{
    public class PartialController : Controller
    {
        EconomyDbContext db = new EconomyDbContext();
        // GET: Partial
        public ActionResult Account()
        {
            ViewBag.Session = Session[Common.CommonConstant.USER_SESSION];
            return PartialView();
        }
        public ActionResult DisplayAdminName()
        {
            ViewBag.Session = Session[Common.Admin.CommonConstantAdmin.ADMIN_SESSION];
            return PartialView();
        }

        public ActionResult DisplayAdminNameHomePage()
        {
            ViewBag.SessionAdmin = Session[Common.Admin.CommonConstantAdmin.ADMIN_SESSION];
            return PartialView();
        }


    }
}