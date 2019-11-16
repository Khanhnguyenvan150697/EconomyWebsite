using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Economy.Common;
using Economy.Models;

namespace Economy.Controllers
{
    public class ProductController : Controller
    {
        ProductDao product = new ProductDao();
        // GET: Product
        public ActionResult Detail(long? id)
        {
            var cmtDao = new CommentDao().lst4Cmt(id);
            ViewBag.comment = cmtDao;

            ViewBag.Session = Session[Common.CommonConstant.USER_SESSION];
            var prod = product.getProductById(id);
            return View(prod);
        }
    }
}