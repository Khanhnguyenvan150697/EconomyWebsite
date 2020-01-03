using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace Economy.Controllers
{
    public class ConfirmCartOrderController : BaseController
    {
        EconomyDbContext db = new EconomyDbContext();

        // GET: ConfirmCartOrder
        public ActionResult NotPayCart()
        {
            var cart = db.CartOrders.Where(x => x.Pay == false).ToList();
            var customer = db.Customers.ToList();
            ViewBag.Customers = customer;
            return View(cart);
        }

        public ActionResult PayButNotShipping()
        {
            var cart = db.CartOrders.Where(x => x.Pay == true && x.StatusShipping == false).ToList();
            var customer = db.Customers.ToList();
            ViewBag.Customers = customer;
            return View(cart);
        }

        public ActionResult PayAndShip()
        {
            var cart = db.CartOrders.Where(x => x.Pay == true && x.StatusShipping == true).ToList();
            var customer = db.Customers.ToList();
            ViewBag.Customers = customer;
            return View(cart);
        }

        public ActionResult ConfirmCart(int id)
        {
            var cartDetail = db.CartOrderDetails.Where(x => x.OrderID == id).ToList();
            var cartOrder = db.CartOrders.Where(x => x.ID == id).FirstOrDefault();
            var cus = db.Customers.Where(x => x.ID == cartOrder.UserID).FirstOrDefault();
            var lstProds = new List<Product>();
            decimal? tongtien = 0;
            foreach (var item in cartDetail)
            {
                Product prod = db.Products.Where(x => x.ID == item.ProductID).Single();
                tongtien += item.Quantity * item.Price;
                lstProds.Add(prod);
            }

            ViewBag.Tongtien = tongtien;
            ViewBag.Products = lstProds;
            ViewBag.NameCustomer = cus;
            ViewBag.IDCartOrder = cartOrder;

            return View(cartDetail);
        }

        [HttpPost]
        public JsonResult PayAndShip(string ttoan, string gihang, int id)
        {
            string result = string.Empty;
            CartOrder cart = db.CartOrders.Where(x => x.ID == id).FirstOrDefault();
            if (cart == null)
            {
                result = "Không tồn tại đơn hàng";
            }
            else
            {
                if (gihang == "Đã giao")
                {
                    cart.StatusShipping = true;
                }
                if (gihang == "Chưa giao")
                {
                    cart.StatusShipping = false;
                }

                if (ttoan == "Đã thanh toán")
                {
                    cart.Pay = true;
                }
                if (ttoan == "Chưa thanh toán")
                {
                    cart.Pay = false;
                }

                db.SaveChanges();
                result = "Cập nhật thành công";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}