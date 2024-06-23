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

        public WishItem GetWishItem(int id)
        {
            return _context.wishItems.Where(x => x.Id == id).FirstOrDefault();
        }

        public WishItem GetWishItem(string title)
        {
            return _context.wishItems.Where(x => x.Title == title).FirstOrDefault();
        }

        public bool WishItemExists(int id)
        {
            return _context.wishItems.Any(x => x.Id == id);
        }

        public ICollection<WishItem> GetWishItems() 
        { 
            return _context.wishItems.OrderBy(x => x.Id).ToList();
        }

        public bool CreateWishItem(WishItem wishItem)
        {
            _context.Add(wishItem);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateWishItem(WishItem wishItem)
        {
            _context.Update(wishItem);
            return Save();
        }

        public bool DeleteWishItem(WishItem wishItem)
        {
            _context.Remove(wishItem);
            return Save();
        }
    }
}
