namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CartOrder")]
    public partial class CartOrder
    {
        public long ID { get; set; }

        [StringLength(150)]
        public string ImageProduct { get; set; }

        public long? ProductID { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public DateTime? DateOrder { get; set; }

        public int? TotalCountProduct { get; set; }

        public bool? ShippingCost { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
