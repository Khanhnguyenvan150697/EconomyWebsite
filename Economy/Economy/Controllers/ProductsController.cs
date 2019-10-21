using Economy.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Economy.Controllers
{
    public class ProductsController : Controller
    {
        EconomyDbContext db = new EconomyDbContext();
        
        
        // Create product
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
                return RedirectToAction("HomeAdmin", "HomeAdmin");
            }
            else
            {
                return View();
            }
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
        //Delete product
        public ActionResult Delete(long? id)
        {

            var pr = db.Products.Find(id);

            if (pr != null)
            {
                db.Products.Remove(pr);
                db.SaveChanges();
                return RedirectToAction("HomeAdmin", "HomeAdmin");
            }
            return RedirectToAction("HomeAdmin", "HomeAdmin");
        }
    }
}