using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Economy.Models;
using Model.EF;

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
        public ActionResult EditCartItem(int ProductID, int Quantity)
        {
            Product checkProd = db.Products.SingleOrDefault(x => x.ID == ProductID);

            List<CartItemModel> lstCartItem = GetListCartItem();

            CartItemModel prod = lstCartItem.SingleOrDefault(x => x.ID == ProductID);

            prod.Quantity = Quantity;
            prod.TotalPrice = Quantity * prod.Price;

            return RedirectToAction("Cart");
        }
    }
}