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
        public ActionResult GoodsReceipt(GoodsReceipt model, IEnumerable<GoodsReceiptDetail> lstModel)
        {
            ViewBag.Supplier = GetSupplier();
            ViewBag.ProductName = GetProduct();
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
    }
}