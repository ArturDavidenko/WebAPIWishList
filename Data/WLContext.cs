using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPIWishList.Models;

namespace WebAPIWishList.Data
{
    public class WLContext : DbContext
    {
        public DbSet<WishItem> wishItems { get; set; }
        public WLContext(DbContextOptions<WLContext> options) : base(options) { }
    }
}
