using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Economy.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace Economy.Controllers
{
    public class HomeAdminController : BaseController
    {
        EconomyDbContext db = new EconomyDbContext();
        // GET: HomeAdmin
        public ActionResult HomeAdmin()
        {
            
            var lstItem = db.Products.ToList();
            return View(lstItem);
        }

        [HttpGet]
        public JsonResult ShowData()
        {
            var lstItem = db.Products.ToList();
            return Json(lstItem, JsonRequestBehavior.AllowGet);
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
                    MoreImg1 = prod.Image1,
                    MoreImg2 = prod.Image2,
                    MoreImg3 = prod.Image3,
                    MoreImg4 = prod.Image4,
                    MoreImg5 = prod.Image5,
                    Description = prod.Description,
                    Detail = prod.Detail
                };
                db.Products.Add(item);
                db.SaveChanges();
                return RedirectToAction("HomeAdmin");
            }
            return View();
        }

        //Get List brands
        public List<Brand> GetBrand()
        {

            List<Brand> brands = db.Brands.ToList();

            return brands;
        }

        //Get List BlogCategory
        public List<BlogCategory> GetBlogCategory()
        {

            List<BlogCategory> blogCate = db.BlogCategories.ToList();

            return blogCate;
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
            ViewBag.Brand = new SelectList(GetBrand(), "Name", "Name");
            ViewBag.Cates = new SelectList(GetCate(), "Name", "Name");

            if (ModelState.IsValid)
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("HomeAdmin", "HomeAdmin");
            }

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

        public JsonResult Demo()
        {
            string error = "sjenlfnc";
            return Json(error, JsonRequestBehavior.AllowGet);
        }

        // Product detail
        [HttpGet]
        public JsonResult Detail(long? id)
        {
            Product prod = db.Products.Where(x => x.ID == id).FirstOrDefault();
            if(prod != null)
            {
                return Json(prod, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        [HttpGet]
        public ActionResult BlogAdmin()
        {
            ViewBag.BlogCate = new SelectList(GetBlogCategory(), "CateName", "CateName");
            return View();
        }
        //BlogAdmin
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogAdmin(BlogModel blog)
        {
            ViewBag.BlogCate = new SelectList(GetBlogCategory(), "CateName", "CateName");
            if (ModelState.IsValid)
            {
                var blg = new Blog()
                {
                    ID = blog.ID,
                    Creater = blog.Creater,
                    BlogCategory = blog.Category,
                    Title = blog.Title,
                    Thumbnail = blog.Thumbnail,
                    CreatedDate = DateTime.Now,
                    ShortContent = blog.ShortContent,
                    Content = blog.Content
                };
                db.Blogs.Add(blg);
                db.SaveChanges();
                return RedirectToAction("BlogAdmin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditBlog(int id)
        {
            ViewBag.BlogCate = new SelectList(GetBlogCategory(), "CateName", "CateName");

            var blog = db.Blogs.Where(x => x.ID == id).FirstOrDefault();

            if(blog != null)
            {
                return View(blog);
            }
            else
            {
                Response.StatusCode = 404;
                return null;
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBlog(Blog blog)
        {
            ViewBag.BlogCate = new SelectList(GetBlogCategory(), "CateName", "CateName");

            if (ModelState.IsValid)
            {
                db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BlogList", "HomeAdmin");
            }
            return View();
        }

        public ActionResult BlogList()
        {
            var blogs = db.Blogs.ToList();
            return View(blogs);
        }

        // Show blog data
        [HttpGet]
        public JsonResult ShowBlogData()
        {
            var lstItem = db.Blogs.ToList();
            return Json(lstItem, JsonRequestBehavior.AllowGet);
        }

        //Delete blog
        public ActionResult DeleteBlog(int id)
        {
            var blog = db.Blogs.Where(x => x.ID == id).FirstOrDefault();
            if(blog != null)
            {
                db.Blogs.Remove(blog);
                db.SaveChanges();
            }
            return RedirectToAction("BlogList");
        }
    }
}