namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GoodsReceipt")]
    public partial class GoodsReceipt
    {
        public int ID { get; set; }

        public int? SupplierID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Deleted { get; set; }
    }
}
