﻿using WebAPIWishList.Models;

namespace WebAPIWishList.Interfaces
{
    public interface IWishListRepository
    {
        ICollection<WishItem> GetWishItems();

        WishItem GetWishItem(int id);

        WishItem GetWishItem(string title);

        bool WishItemExists(int id);

    }
}
