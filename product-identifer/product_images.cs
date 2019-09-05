namespace product_identifer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Images
    {
        [Key]
        [StringLength(15)]
        public string material_no { get; set; }

        [Required]
        [StringLength(20)]
        public string file_name { get; set; }

        public virtual Product product { get; set; }
    }
}
