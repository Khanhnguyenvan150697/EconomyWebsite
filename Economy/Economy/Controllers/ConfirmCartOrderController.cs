using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace Economy.Controllers
{
    public class ConfirmCartOrderController : Controller
    {
        EconomyDbContext db = new EconomyDbContext();
        
        // GET: ConfirmCartOrder
        public ActionResult NotPayCart()
        {
            var notPayed = db.CartOrders.Where(x => x.Pay == false).ToList();
            var customer = db.Customers.ToList();
            ViewBag.Customers = customer;
            return View(notPayed);
        }

        public ActionResult PayButNotShipping()
        {
            var notPayed = db.CartOrders.Where(x => x.Pay == false).ToList();
            var customer = db.Customers.ToList();
            ViewBag.Customers = customer;
            return View(notPayed);
        }

        public ActionResult PayAndShip()
        {
            var notPayed = db.CartOrders.Where(x => x.Pay == false).ToList();
            var customer = db.Customers.ToList();
            ViewBag.Customers = customer;
            return View(notPayed);
        }

        public ActionResult ConfirmCart(int id)
        {
            var cartDetail = db.CartOrderDetails.Where(x => x.OrderID == id).ToList();
            var cartOrder = db.CartOrders.Where(x => x.ID == id).FirstOrDefault();
            var cus = db.Customers.Where(x => x.ID == cartOrder.UserID).FirstOrDefault();
            var lstProds = new List<Product>();
            foreach(var item in cartDetail)
            {
                Product prod = db.Products.Where(x => x.ID == item.ProductID).Single();
                lstProds.Add(prod);
            }

            
            for(int i = 0; i<=cartDetail.Count; i++)
            {
                
            }
            ViewBag.Products = lstProds;
            ViewBag.NameCustomer = cus;
            ViewBag.IDCartOrder = cartOrder;

            return View(cartDetail);
        }
    }
}