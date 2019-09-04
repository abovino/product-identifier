namespace product_identifer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductModel : DbContext
    {
        public ProductModel()
            : base("name=ProductModel")
        {
        }

        public virtual DbSet<Product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.material_no)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.hierarchy_id)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.uom)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.upc)
                .IsUnicode(false);
        }
    }
}
