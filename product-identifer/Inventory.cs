namespace product_identifer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("inventory")]
    public partial class Inventory
    {
        [Required]
        [StringLength(15)]
        public string material_no { get; set; }

        public int qty { get; set; }

        [Required]
        [StringLength(4)]
        public string plant_id { get; set; }

        [Required]
        [StringLength(3)]
        public string bin_location { get; set; }

        public int id { get; set; }

        public virtual Plant plant { get; set; }

        public virtual Product product { get; set; }
    }
}
