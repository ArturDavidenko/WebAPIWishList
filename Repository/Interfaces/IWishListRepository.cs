using WebAPIWishList.Models;

namespace WebAPIWishList.Repository.Interfaces
{
    public interface IWishListRepository
    {
        ICollection<WishItem> GetWishItems();

        WishItem GetWishItem(int id);

        WishItem GetWishItem(string title);

        bool WishItemExists(int id);

        bool CreateWishItem(WishItem wishItem);

        bool Save();

        bool UpdateWishItem(WishItem wishItem, int wishItemId);

        bool DeleteWishItem(WishItem wishItem);

    }
}
