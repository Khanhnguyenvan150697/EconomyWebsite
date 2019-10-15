using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economy.Models
{
    public class AdminAccModel
    {
        [Required(ErrorMessage ="you have to enter your email")]
        public string AdminEmail { set; get; }
        [Required(ErrorMessage = "you have to enter your password")]
        public string AdminPassword { set; get; }

    }
}