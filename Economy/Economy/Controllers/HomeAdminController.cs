using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Economy.Models;

namespace Economy.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: HomeAdmin
        public ActionResult HomeAdmin()
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            var item = db.Products.ToList();

            return View(item);
        }
    }
}