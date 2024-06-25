using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPIWishList.Models;

namespace WebAPIWishList.Data
{
    public class DBContext : DbContext
    {
        public DbSet<WishItem> wishItems { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }


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
