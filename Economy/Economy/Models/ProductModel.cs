using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Economy.Models
{
    public class ProductModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Status { get; set; }
        public string Price { get; set; }
    }
}