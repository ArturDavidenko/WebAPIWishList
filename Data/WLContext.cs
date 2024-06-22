using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPIWishList.Models;

namespace WebAPIWishList.Data
{
    public class WLContext : DbContext
    {
        public DbSet<WishItem> wishItems { get; set; }
        public WLContext(DbContextOptions<WLContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishItem>()
                .HasKey(w => w.Id);
            modelBuilder.Entity<WishItem>()
                .Property(w => w.Id)
                .ValueGeneratedOnAdd(); // Указывает, что Id будет генерироваться при добавлении
        }
    }
}
