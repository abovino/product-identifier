namespace product_identifer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [Key]
        [StringLength(15)]
        public string material_no { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        [Required]
        [StringLength(4)]
        public string hierarchy_id { get; set; }

        [Required]
        [StringLength(2)]
        public string uom { get; set; }

        [Required]
        [StringLength(13)]
        public string upc { get; set; }

        public int? pack_size { get; set; }
    }
}
