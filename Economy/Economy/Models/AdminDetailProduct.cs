using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economy.Models
{
    public class AdminDetailProduct
    {
        public long ID { set; get; }
        public string ProductName { set; get; }
        public string BrandName { set; get; }
        public string Image { set; get; }
        public string CategoryName { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public decimal PromotionPrice { set; get; }
        public string Description { set; get; }
        public string Detail { set; get; }
    }
}