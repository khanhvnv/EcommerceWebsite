using Microsoft.EntityFrameworkCore;
using EcommerceShared.Models;

namespace EcommerceApi.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed data for Category menu
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bánh kem", Description ="Bánh kem, bánh kem bắp, bánh kem nhân mứt" },
                new Category { Id = 2, Name = "Bánh nướng", Description = "Bánh mì, bánh quy, donut"},
                new Category { Id = 3, Name = "Bánh lạnh", Description = "Bánh flan, bánh su kem, pudding "},
                new Category { Id = 4, Name = "Cà rem", Description = "Kem vani, kem đậu xanh, kem dâu, kem chuối"}
            );
            // Seed data for products of each category
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Bánh kem nhân dâu", Price = 335000, ImageURL = "/images/cakes/Banh-Kem-Dau-1.jpg", CategoryId = 1},
                new Product { Id = 2, Name = "Bánh kem bắp", Price = 335000, ImageURL = "/images/cakes/Banh-Kem-Bap-1-2.jpg", CategoryId = 1},
                new Product { Id = 3, Name = "Bánh kem nhân mứt", Price = 335000, ImageURL = "/images/cakes/Banh-Kem-Thom-10-1.jpg", CategoryId = 1},

                new Product { Id = 4, Name = "Bánh mì", Price = 23000, ImageURL = "/images/baked-cakes/sandwich-ngu-coc.jpg", CategoryId = 2},
                new Product { Id = 5, Name = "Bánh quy", Price = 25000, ImageURL = "/images/baked-cakes/Quy-Bo-Dau-Phong.jpg", CategoryId = 2},
                new Product { Id = 6, Name = "Bánh donut", Price = 15000, ImageURL = "/images/baked-cakes/Banh-Donut.jpg", CategoryId = 2},

                new Product { Id = 7, Name = "Bánh flan", Price = 12000, ImageURL = "/images/cold-cakes/Banh-Flan-2.jpg", CategoryId = 3},
                new Product { Id = 8, Name = "Bánh su kem", Price = 33000, ImageURL = "/images/cold-cakes/banh_su_kem.jpg", CategoryId = 3},
                new Product { Id = 9, Name = "Pudding", Price = 35000, ImageURL = "/images/cold-cakes/pudding-xoai.jpg", CategoryId = 3},

                new Product { Id = 10, Name = "Kem vani", Price = 13000, ImageURL = "/images/ice-cream/Kem-Vani.jpg", CategoryId = 4},
                new Product { Id = 11, Name = "Kem đậu xanh", Price = 13000, ImageURL = "/images/ice-cream/Kem-Dau-Xanh.jpg", CategoryId = 4},
                new Product { Id = 12, Name = "Kem dâu", Price = 13000, ImageURL = "/images/ice-cream/Kem-Dau.jpg", CategoryId = 4}
            );
        }
    }
}
