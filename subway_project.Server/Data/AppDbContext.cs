using Microsoft.EntityFrameworkCore;
using subway_project.Server.Models;


namespace subway_project.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sub> Sub { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<SubProduct> SubProduct { get; set; }
        public DbSet<Specials> Specials { get; set; }
        public DbSet<OrderSpecials> OrderSpecials { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<SubCategory>()
                .HasIndex(sc => sc.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany()
                .HasForeignKey(p => p.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<SubProduct>()
                .HasKey(op => new { op.SubId, op.ProductId });

            modelBuilder.Entity<OrderSpecials>()
               .HasKey(op => new { op.OrderId, op.SpecialId });

            modelBuilder.Entity<SpecialProduct>()
                .HasKey(sp => new { sp.SpecialId, sp.ProductId });

            modelBuilder.Entity<SpecialProduct>()
                .HasOne(sp => sp.Special)
                .WithMany(s => s.SpecialProducts)
                .HasForeignKey(sp => sp.SpecialId);

            modelBuilder.Entity<SpecialProduct>()
                .HasOne(sp => sp.Product)
                .WithMany()
                .HasForeignKey(sp => sp.ProductId);
        }
    }
}
