namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoodsReceiptDetail")]
    public partial class GoodsReceiptDetail
    {
        public int ID { get; set; }

        public int? GoodsReceiptID { get; set; }

        public int? ProductID { get; set; }

        public decimal? ProductPrice { get; set; }

        public int? ProductQuantity { get; set; }
    }
}
