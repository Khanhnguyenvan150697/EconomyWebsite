using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Economy.Models
{
    public class BlogModel
    {
        public int ID { get; set; }
        [Required]
        public string Creater { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortContent { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Thumbnail { get; set; }

    }
}