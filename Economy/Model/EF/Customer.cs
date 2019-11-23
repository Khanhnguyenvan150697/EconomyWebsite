namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; }

        public string Address { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public long? UserID { get; set; }
    }
}
