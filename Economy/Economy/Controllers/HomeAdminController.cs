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
        EconomyDbContext db = new EconomyDbContext();
        // GET: HomeAdmin
        public ActionResult HomeAdmin(int? page)
        {
            const int PAGESIZE = 5;
            int pageNumber = (page ?? 1);

            var item = db.Products.OrderBy(x => x.ID).ToPagedList(pageNumber, PAGESIZE);

            return View(item);
        }

        [HttpGet]
        public JsonResult ShowData(int page, int pageSize)
        {
            var _prod = db.Products.ToList();
            return Json(_prod, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Brand = new SelectList(GetBrand(), "Name", "Name");
            ViewBag.Cates = new SelectList(GetCate(), "Name", "Name");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AddNewProduct prod)
        {
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
                    Quantity = prod.Quantity,
                    PromotionPrice = prod.PromotionPrice,
                    Image = prod.Image,
                    Description = prod.Description,
                    Detail = prod.Detail
                };
                db.Products.Add(item);
                db.SaveChanges();
            }
            return RedirectToAction("HomeAdmin");
        }

        //Get List brands
        public List<Brand> GetBrand()
        {

            List<Brand> brands = db.Brands.ToList();

            return brands;
        }

        //Get List categories
        public List<Category> GetCate()
        {
            List<Category> cates = db.Categories.ToList();
            return cates;
        }

        //Edit product
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            var prod = db.Products.Find(id);

            ViewBag.Brand = new SelectList(GetBrand(), "Name", "Name");
            ViewBag.Cates = new SelectList(GetCate(), "Name", "Name");

            if (prod != null)
            {
                return View(prod);
            }
            else
            {
                Response.StatusCode = 404;
                return null;
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HomeAdmin", "HomeAdmin");
            }
            ViewBag.Brand = new SelectList(GetBrand(), "Name", "Name");
            ViewBag.Cates = new SelectList(GetCate(), "Name", "Name");

            return View();
        }
        [HttpPost]
        public JsonResult Delete(long? id)
        {
            string result = string.Empty;
            var prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            if(prod != null)
            {
                db.Products.Remove(prod);
                db.SaveChanges();
                result = "Xóa thành công";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}