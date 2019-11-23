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

        public DateTime? DateOrder { get; set; }

        public bool? StatusShipping { get; set; }

        public DateTime? DateShipping { get; set; }

        public bool? Pay { get; set; }

        [StringLength(150)]
        public string ImageProduct { get; set; }

        public long? UserID { get; set; }

        public int? Promotion { get; set; }

        public bool? IgnoredCart { get; set; }

        public bool? DeletedCart { get; set; }
    }
}
