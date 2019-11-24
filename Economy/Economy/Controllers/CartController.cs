using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Economy.Models;
using Model.EF;
using Economy.Common;

namespace Economy.Controllers
{
    public class CartController : Controller
    {
        EconomyDbContext db = new EconomyDbContext();
        
        //Get cartItem
        public List<CartItemModel> GetListCartItem()
        {
            List<CartItemModel> lstCartItem = Session["cart"] as List<CartItemModel>;
            if(lstCartItem == null)
            {
                lstCartItem = new List<CartItemModel>();
                Session["cart"] = lstCartItem;
            }
            return lstCartItem;
        }
        //Add Cart item
        [HttpPost]
        public ActionResult AddCartItem(long id, string strUrl)
        {
            Product prod = db.Products.SingleOrDefault(x => x.ID == id);

            if(prod == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<CartItemModel> lstCartItem = GetListCartItem();

            CartItemModel checkProd = lstCartItem.SingleOrDefault(x => x.ID == id);  

            if(checkProd != null)
            {
                if(prod.Quantity < checkProd.Quantity)
                {
                    return Content("<script>alert(\"Sản phẩm đã hết hàng\")</script>");
                }
                checkProd.Quantity++;
                checkProd.TotalPrice = checkProd.Price * checkProd.Quantity;
                ViewBag.TotalQuantity = TotalQuantity();
                ViewBag.TotalPrice = TotalPrice(); 
                return PartialView("CartHeader");
            }

            CartItemModel icart = new CartItemModel(id);
            if(prod.Quantity < icart.Quantity)
            {
                return Content("<script>alert(\"Sản phẩm đã hết hàng\")</script>");
            }
            lstCartItem.Add(icart);
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            return PartialView("CartHeader");
        }
        
        //Calculate total quantity
        public int? TotalQuantity()
        {
            List<CartItemModel> lstCartItem = Session["cart"] as List<CartItemModel>;
            if(lstCartItem == null)
            {
                return 0;
            }
            return lstCartItem.Sum(x => x.Quantity);
        }

        //Calculate total price
        public decimal? TotalPrice()
        {
            List<CartItemModel> lstCartItem = Session["cart"] as List<CartItemModel>;
            if (lstCartItem == null)
            {
                return 0;
            }
            return lstCartItem.Sum(x => x.TotalPrice);
        }
        // Create cartHeaderPartial
        public ActionResult CartHeader()
        {
            if(TotalQuantity() == 0)
            {
                ViewBag.TotalQuantity = 0;
                ViewBag.TotalPrice = 0;
                return PartialView();
            }
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            return PartialView();
        }

        // GET: Cart
        public ActionResult Cart()
        {
            List<CartItemModel> lstCartItem = GetListCartItem();
            ViewBag.TotalQuantity = TotalQuantity();
            ViewBag.TotalPrice = TotalPrice();
            ViewBag.Session = Session[Common.CommonConstant.USER_SESSION];
            return View(lstCartItem);
        }

        // Edit cart items
        public ActionResult EditCartItem(int id)
        {
            if(Session["cart"] == null)
            {
                return RedirectToAction("Index","Home");
            }

            Product prod = db.Products.SingleOrDefault(x => x.ID == id);

            if(prod == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<CartItemModel> lstCartItem = GetListCartItem();

            CartItemModel icart = lstCartItem.SingleOrDefault(x => x.ID == id);

            if(icart == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Cart = lstCartItem;

            return View(icart);
        }

        //edit cart item
        [HttpPost]
        public ActionResult EditCartItem(CartItemModel icart)
        {
            Product checkProd = db.Products.SingleOrDefault(x => x.ID == icart.ProductID);

            if(checkProd.Quantity < icart.Quantity)
            {
                return View("OverQuantity");
            }

            List<CartItemModel> lstCartItem = GetListCartItem();

            CartItemModel prodUpdate = lstCartItem.SingleOrDefault(x => x.ID == icart.ProductID);

            prodUpdate.Quantity = icart.Quantity;
            prodUpdate.TotalPrice = icart.Quantity * prodUpdate.Price;

            return RedirectToAction("Cart");
        }

        //Delete cart item
        public ActionResult DeleteCartItem(int id)
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Product prod = db.Products.SingleOrDefault(x => x.ID == id);

            if (prod == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            List<CartItemModel> lstCartItem = GetListCartItem();

            CartItemModel icart = lstCartItem.SingleOrDefault(x => x.ID == id);

            if (icart == null)
            {
                return RedirectToAction("Index", "Home");
            }
            lstCartItem.Remove(icart);
            return RedirectToAction("Cart");
        }

        //Create order cart func
        public ActionResult Order(Customer cus)
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Customer customer = new Customer();
            if(Session[Common.CommonConstant.USER_SESSION] == null)
            {
                customer = cus;
                db.Customers.Add(customer);
                db.SaveChanges();

            }
            else
            {
                UserLogin _user = Session[Common.CommonConstant.USER_SESSION] as UserLogin;
                customer.CustomerName = _user.UserName;
                customer.Email = _user.UserEmail;
                customer.Address = cus.Address;
                customer.Phone = cus.Phone;
                customer.UserID = _user.UserID;

                db.Customers.Add(customer);
                db.SaveChanges();
            }
            CartOrder cartOr = new CartOrder();
            cartOr.UserID = customer.ID;
            cartOr.DateOrder = DateTime.Now;
            cartOr.StatusShipping = false;
            cartOr.Pay = false;
            cartOr.Promotion = 0;
            cartOr.IgnoredCart = false;
            cartOr.DeletedCart = false;

            db.CartOrders.Add(cartOr);
            db.SaveChanges(); // savechanges để phát sinh ID của CartOrder lưu vào CartOrderDetail

            List<CartItemModel> lstCartItem = GetListCartItem();
            foreach(var item in lstCartItem)
            {
                CartOrderDetail cartDetail = new CartOrderDetail();

                cartDetail.OrderID = cartOr.ID;
                cartDetail.ProductID = item.ProductID;
                cartDetail.ProductName = item.ProductName;
                cartDetail.Quantity = item.Quantity;
                cartDetail.Price = item.Price;

                db.CartOrderDetails.Add(cartDetail);
            }
            db.SaveChanges();

            Session["cart"] = null;

            return RedirectToAction("ThankYouToOrder");
        }

        public ActionResult ThankYouToOrder()
        {
            return View();
        }
    }
}