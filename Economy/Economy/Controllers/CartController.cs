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
        // GET: Cart
        public ActionResult Cart()
        {
            return View();
        }
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
                    return View("Notification");
                }
                checkProd.Quantity++;
                return Redirect(strUrl);
            }

            CartItemModel icart = new CartItemModel(id);
            if(prod.Quantity < icart.Quantity)
            {
                return View("Notification");
            }
            lstCartItem.Add(icart);
            return Redirect(strUrl);
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
    }
}