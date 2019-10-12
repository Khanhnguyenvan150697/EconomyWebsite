using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economy.Models
{
    public class UserModel
    {
        [Required(ErrorMessage ="You have to enter your email")]
        public string Email { set; get; }
        [Required(ErrorMessage = "You have to enter your password")]
        public string Password { set; get; }
        public string UserName { set; get; }
    }
}