namespace product_identifer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductsModel : DbContext
    {
        public ProductsModel()
            : base("name=ProductsDbContext")
        {
        }

        public virtual DbSet<Inventory> inventories { get; set; }
        public virtual DbSet<Plant> plants { get; set; }
        public virtual DbSet<Product_Hierarchies> product_hierarchies { get; set; }
        public virtual DbSet<Product_Images> product_images { get; set; }
        public virtual DbSet<Product> products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .Property(e => e.material_no)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.plant_id)
                .IsUnicode(false);

            modelBuilder.Entity<Inventory>()
                .Property(e => e.bin_location)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .Property(e => e.plant_id)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<Plant>()
                .HasMany(e => e.inventories)
                .WithRequired(e => e.plant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product_Hierarchies>()
                .Property(e => e.hierarchy_id)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Hierarchies>()
                .Property(e => e.hierarchy_description)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Hierarchies>()
                .HasMany(e => e.products)
                .WithRequired(e => e.product_hierarchies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product_Images>()
                .Property(e => e.material_no)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Images>()
                .Property(e => e.file_name)
                .IsUnicode(false);

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

            modelBuilder.Entity<Product>()
                .HasMany(e => e.inventories)
                .WithRequired(e => e.product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.product_images)
                .WithRequired(e => e.product);
        }
    }
}
