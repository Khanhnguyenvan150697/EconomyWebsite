using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Economy.Models;
using PagedList;
using PagedList.Mvc;

namespace Economy.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: HomeAdmin
        public ActionResult HomeAdmin(int? page)
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            const int PAGESIZE = 5;
            int pageNumber = (page ?? 1);

            var item = db.Products.OrderBy(x => x.ID).ToPagedList(pageNumber, PAGESIZE);

            return View(item);
        }
    }
}