namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CartOrderDetail")]
    public partial class CartOrderDetail
    {
        public int ID { get; set; }

        public long? OrderID { get; set; }

        public long? ProductID { get; set; }

        [StringLength(250)]
        public string ProductName { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
