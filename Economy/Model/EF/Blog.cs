namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Creater { get; set; }

        [StringLength(50)]
        public string BlogCategory { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public string ShortContent { get; set; }

        public string Content { get; set; }
    }
}
