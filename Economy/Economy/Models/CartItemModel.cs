using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace Economy.Models
{
    public class CartItemModel
    {
        EconomyDbContext db = new EconomyDbContext();
        public long ID { get; set; }
        public string ProductName { set; get; }

        public string ImageProduct { get; set; }

        public long? ProductID { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public decimal? TotalPrice { get; set; }

        public CartItemModel(long id)
        {
            this.ID = id;
            Product prod = db.Products.Single(x => x.ID == id);
            ProductName = prod.Name;
            ImageProduct = prod.Image;
            ProductID = prod.ID;
            Price = prod.Price;
            Quantity = 1;
            TotalPrice = prod.Quantity * prod.Price;
        }
    }
}