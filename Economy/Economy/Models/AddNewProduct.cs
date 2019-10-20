using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Model.EF;

namespace Economy.Models
{
    public class AddNewProduct
    {
        public long ID { set; get; }
        [Required(ErrorMessage ="Enter your product name...")]
        public string ProductName { set; get; }
        [Required(ErrorMessage = "Enter brand name...")]
        public string BrandName { set; get; }
        [Required(ErrorMessage ="You don't choose a image")]
        public string Image { set; get; }
        [Required(ErrorMessage = "Enter category name...")]
        public string CategoryName { set; get; }
        [Required(ErrorMessage = "Enter price...")]
        public decimal Price { set; get; }
        [Required(ErrorMessage = "Enter promotion price")]
        public decimal PromotionPrice { set; get; }
        [Required(ErrorMessage = "Enter description")]
        public string Description { set; get; }
    }
}