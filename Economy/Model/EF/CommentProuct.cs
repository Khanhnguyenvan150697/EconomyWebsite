namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentProuct")]
    public partial class CommentProuct
    {
        public int ID { get; set; }

        public long? ProductID { get; set; }

        public long? UserID { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        public string Avatar { get; set; }

        public string CmtContent { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
