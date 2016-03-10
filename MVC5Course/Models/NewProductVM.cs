using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Models
{
    public class NewProductVM
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(80)]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 9999)]
        public Nullable<decimal> Price { get; set; }
    }
}