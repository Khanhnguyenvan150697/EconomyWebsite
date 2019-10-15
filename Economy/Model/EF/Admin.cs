namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        public int IDAdmin { get; set; }

        [StringLength(100)]
        public string AdminName { get; set; }

        [StringLength(100)]
        public string AdminEmail { get; set; }

        [StringLength(100)]
        public string AdminPassword { get; set; }
    }
}
