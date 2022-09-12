using FianlProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FianlProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }

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
