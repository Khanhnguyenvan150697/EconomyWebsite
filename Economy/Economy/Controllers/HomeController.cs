using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Economy.Common;
using Economy.Models;
using Model.EF;
using Model.Dao;

namespace Economy.Controllers
{
    public class HomeController : Controller
    {
        ProductDao prodDao = new ProductDao();
        CategoryDao cateDao = new CategoryDao();
        BrandDao brandDao = new BrandDao();

        // GET: Home
        public ActionResult Index()
        {
            var listAllProducts = prodDao.getAllProduct();
            return View(listAllProducts);
        }

        public ActionResult CategoryTab()
        {
            ViewBag.Camera = prodDao.getCamera();
            ViewBag.Lens = prodDao.getLens();
            ViewBag.Tripod = prodDao.getTripod();
            ViewBag.Apple = prodDao.getApple();
            ViewBag.Other = prodDao.getOther();
            return PartialView();
        }

        //Category partial
        public ActionResult Category()
        {
            ViewBag.Category = cateDao.categories();
            return PartialView();
        }
        public ActionResult ProductByCategory(string cate)
        {
            var prodsCate = prodDao.GetAllProductByCategory(cate);
            return View(prodsCate);
        }

        //Brand partial
        public ActionResult Brand()
        {
            ViewBag.Brand = brandDao.Brands();
            return PartialView();
        }

        public ActionResult ProductByBrand(string brand)
        {
            var prodsBrand = prodDao.GetAllProductByBrand(brand);
            return View(prodsBrand);
        }
        [HttpGet]
        public ActionResult SearchProductGet(string keyword)
        {
            var listAllProducts = prodDao.getAllProductSearch(keyword);
            ViewBag.Keyword = keyword;
            return View(listAllProducts);
        }
        [HttpPost]
        public ActionResult SearchProductPost(string keyword, FormCollection fc)
        {
            return RedirectToAction("SearchProductGet", new { @keyword=keyword});
        }
        //Search using ajax
        public ActionResult SearchProductPartial(string keyword)
        {
            var listAllProducts = prodDao.getAllProductSearch(keyword);
            return PartialView(listAllProducts);
        }
    }
}