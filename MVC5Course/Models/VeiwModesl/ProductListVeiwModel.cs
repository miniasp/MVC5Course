using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.VeiwModesl
{
    public class ProductListVeiwModel : IValidatableObject
    {
        [Required]
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Stock < 100 && this.Price > 20)
            {
                yield return new ValidationResult("庫存與商品金額的條件錯誤", new string[] { "Price" });
            }
        }
    }
}