using WebAPIWishList.Models;

namespace WebAPIWishList.Interfaces
{
    public interface IWishListRepository
    {
        ICollection<WishItem> GetWishItems();
    }
}
