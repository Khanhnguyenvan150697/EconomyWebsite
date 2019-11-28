using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace Economy.Controllers
{
    public class GoodsReceiptController : Controller
    {
        EconomyDbContext db = new EconomyDbContext();

        // GET: GoodsReceipt
        [HttpGet]
        public ActionResult GoodsReceipt()
        {
            ViewBag.Supplier = GetSupplier();
            ViewBag.ProductName = GetProduct();
            return View();
        }
        [HttpPost]
        public ActionResult GoodsReceipt(GoodsReceipt goodsre, IEnumerable<GoodsReceiptDetail> lstgoodsreDetail)
        {
            ViewBag.Supplier = GetSupplier();
            ViewBag.ProductName = GetProduct();

            goodsre.Deleted = false;
            db.GoodsReceipts.Add(goodsre);
            db.SaveChanges(); // create ID to save into GoodsReceiptDetail

            Product prod;
            foreach (var item in lstgoodsreDetail)
            {
                // update quantity of product table
                prod = db.Products.Single(x => x.ID == item.ProductID);
                prod.Quantity += item.ProductQuantity;
                item.GoodsReceiptID = goodsre.ID;
            }
            db.GoodsReceiptDetails.AddRange(lstgoodsreDetail);
            db.SaveChanges();
            return View();
        }

        //Get list supplier
        public List<Supplier> GetSupplier()
        {

            List<Supplier> suppliers = db.Suppliers.ToList();

            return suppliers;
        }
        //Get list supplier
        public List<Product> GetProduct()
        {

            List<Product> productName = db.Products.ToList();

            return productName;
        }

        //Check quantity of product
        [HttpGet]
        public ActionResult CheckQuantity()
        {
            List<Product> lstProds = db.Products.Where(x =>x.Quantity <= 4).ToList();
            return View(lstProds);
        }
        [HttpGet]
        public ActionResult GoodsReceiptProductDetail(int? id)
        {
            ViewBag.Supplier = GetSupplier();
            if(id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var prod = db.Products.SingleOrDefault(x => x.ID == id);
            if(prod == null)
            {
                return HttpNotFound();
            }
            return View(prod);
        }
        [HttpPost]
        public ActionResult GoodsReceiptProductDetail(GoodsReceipt goodsre, GoodsReceiptDetail goodsreDetail)
        {
            ViewBag.Supplier = GetSupplier();

            goodsre.Deleted = false;
            db.GoodsReceipts.Add(goodsre);
            db.SaveChanges(); // create ID to save into GoodsReceiptDetail

            goodsreDetail.GoodsReceiptID = goodsre.ID;
            Product prod = db.Products.Single(x => x.ID == goodsreDetail.ProductID);
            prod.Quantity += goodsreDetail.ProductQuantity;
            db.GoodsReceiptDetails.Add(goodsreDetail);
            db.SaveChanges();
            return RedirectToAction("CheckQuantity");
        }
    }
}