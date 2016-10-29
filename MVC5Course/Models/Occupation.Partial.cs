namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OccupationMetaData))]
    public partial class Occupation
    {
    }
    
    public partial class OccupationMetaData
    {
        [Required]
        public int OccupationId { get; set; }
        
        [StringLength(60, ErrorMessage="欄位長度不得大於 60 個字元")]
        public string OccupationName { get; set; }
    
        public virtual ICollection<Client> Client { get; set; }
    }
}
