namespace product_identifer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            inventories = new HashSet<Inventory>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> inventories { get; set; }

        public virtual Product_Hierarchies product_hierarchies { get; set; }

        public virtual Product_Images product_images { get; set; }

    }
}
