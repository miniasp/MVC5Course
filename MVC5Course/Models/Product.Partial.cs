
namespace MVC5Course.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

[MetadataType(typeof(ProductMetaData))]
public partial class Product
{
}

public partial class ProductMetaData
{

    [Required]

    public int ProductId { get; set; }
    
    [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]

    public string ProductName { get; set; }

    public Nullable<decimal> Price { get; set; }

    public Nullable<bool> Active { get; set; }

    public Nullable<decimal> Stock { get; set; }



    public virtual ICollection<OrderLine> OrderLine { get; set; }

}

}
