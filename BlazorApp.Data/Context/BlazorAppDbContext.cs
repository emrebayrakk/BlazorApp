using BlazorApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data.Context
{
    public class BlazorAppDbContext : DbContext
    {
        public BlazorAppDbContext(DbContextOptions<BlazorAppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "Data Source=DESKTOP-P87BUPQ;Initial Catalog=BlazorAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(connStr);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in entries)
            {
               if (item.State == EntityState.Added)
               {
                  item.Property(a => a.CreatedDate).CurrentValue = DateTime.Now;
               }
               if (item.State == EntityState.Modified)
               {
                  item.Property(a => a.UpdatedDate).CurrentValue = DateTime.Now;
               }
            }
            return base.SaveChanges();
        }
        public DbSet<User> Users { get; set; }
    }
}
