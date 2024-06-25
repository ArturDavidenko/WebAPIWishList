using WebAPIWishList.Data;
using WebAPIWishList.Models;
using WebAPIWishList.Repository.Interfaces;

namespace WebAPIWishList.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private readonly DBContext _context;
   
        public WishListRepository(DBContext context) 
        { 
            _context = context;
        }

        public WishItem GetWishItem(int id)
        {
            if (!WishItemExists(id))
                return null; // write good exception not null!

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
            if (wishItem == null)
                return false;

            var wishItems = GetWishItems()
                .Where(w => w.Title.Trim().ToUpper() == wishItem.Title.TrimEnd().ToUpper()).FirstOrDefault();

            if (wishItems != null)
                return false;
            
            _context.Add(wishItem);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateWishItem(WishItem updateWishItem, int wishItemId)
        {
            if (wishItemId != updateWishItem.Id)
                return false;

            if (updateWishItem == null)
                return false;

            if (!WishItemExists(updateWishItem.Id))
                return false;

            _context.Update(updateWishItem);
            return Save();
        }

        public bool DeleteWishItem(WishItem wishItem)
        {
            if (wishItem == null) 
                return false;

            _context.Remove(wishItem);
            return Save();
        }
    }
}
