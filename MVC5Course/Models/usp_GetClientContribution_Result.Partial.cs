namespace MVC5Course.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(usp_GetClientContribution_ResultMetaData))]
    public partial class usp_GetClientContribution_Result
    {
    }
    
    public partial class usp_GetClientContribution_ResultMetaData
    {
        [Required]
        public int ClientId { get; set; }
        
        [StringLength(40, ErrorMessage="欄位長度不得大於 40 個字元")]
        public string FirstName { get; set; }
        
        [StringLength(40, ErrorMessage="欄位長度不得大於 40 個字元")]
        public string LastName { get; set; }
        public Nullable<decimal> OrderTotal { get; set; }
    }
}
