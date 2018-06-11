using FirstEFProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace FirstEFProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }
         
       protected override void  OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(30);

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(30);
            
        }
    }
}