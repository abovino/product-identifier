namespace product_identifer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Plant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plant()
        {
            inventories = new HashSet<Inventory>();
        }

        [Key]
        [StringLength(4)]
        public string plant_id { get; set; }

        [Required]
        [StringLength(25)]
        public string city { get; set; }

        [Required]
        [StringLength(2)]
        public string state { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> inventories { get; set; }
    }
}
