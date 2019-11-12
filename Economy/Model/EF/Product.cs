namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public string MoreImg1 { get; set; }

        public string MoreImg2 { get; set; }

        public string MoreImg3 { get; set; }

        public string MoreImg4 { get; set; }

        public string MoreImg5 { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Quantity { get; set; }

        [StringLength(150)]
        public string BrandName { get; set; }

        [StringLength(150)]
        public string CategoryName { get; set; }

        public string Detail { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? Status { get; set; }
    }
}
