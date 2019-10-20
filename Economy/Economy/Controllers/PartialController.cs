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


        [HttpGet]
        public ActionResult PopupModal()
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            ViewBag.Brand = new SelectList(GetBrand(), "Name", "Name");
            ViewBag.Cates = new SelectList(GetCate(), "Name", "Name");
            return PartialView();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PopupModal(AddNewProduct prod)
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            // new SelectList(ListData,"field saved to CSDL","field displayed")

            ViewBag.Brand = new SelectList(GetBrand(), "Name", "Name");
            ViewBag.Cates = new SelectList(GetCate(), "Name", "Name");

            if (ModelState.IsValid)
            {
                var item = new Product()
                {
                    Name = prod.ProductName,
                    BrandName = prod.BrandName,
                    CategoryName = prod.CategoryName,
                    Price = prod.Price,
                    PromotionPrice = prod.PromotionPrice,
                    Image = prod.Image,
                    Description = prod.Description
                };

                db.Products.Add(item);
                db.SaveChanges();
                return RedirectToAction("HomeAdmin","HomeAdmin");
            }
            else
            {
                return PartialView();
            }
        }

        //Get List brands
        public List<Brand> GetBrand()
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            List<Brand> brands = db.Brands.ToList();

            return brands;
        }

        //Get List categories
        public List<Category> GetCate()
        {
            EconomyDbContext db = null;
            db = new EconomyDbContext();

            List<Category> cates = db.Categories.ToList();
            return cates;
        }
    }
}