using WebAPIWishList.Data;
using WebAPIWishList.Interfaces;
using WebAPIWishList.Models;

namespace WebAPIWishList.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private readonly WLContext _context;
        public WishListRepository(WLContext context) 
        { 
            _context = context;
        }

        public ICollection<WishItem> GetWishItems() 
        { 
            return _context.wishItems.OrderBy(x => x.Id).ToList();
        }
    }
}
