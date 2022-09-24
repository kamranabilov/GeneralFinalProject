using FianlProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq;

namespace FianlProject.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<Furnitureimage> Furnitureimages { get; set; }
		public DbSet<FurnitureDescription> FurnitureDescriptions { get; set; }
		public DbSet<Category> Categories { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
		public DbSet<Wishlistitem> WishlistItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                )
            {
                item.SetColumnType("decimal(6,2)");
            }
            modelBuilder.Entity<Setting>()
                        .HasIndex(s => s.Key)
                        .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        
        
    }

}
