using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economy.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Trường này không được để trống")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Phone { set; get; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Address { set; get; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Password { set; get; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string RePassword { set; get; }
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Avatar { set; get; }
    }
}