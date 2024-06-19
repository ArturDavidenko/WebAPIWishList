using Microsoft.AspNetCore.Mvc;
using WebAPIWishList.Data;
using WebAPIWishList.Interfaces;
using WebAPIWishList.Models;

namespace WebAPIWishList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishItemController : Controller
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly WLContext _context;
        public WishItemController(IWishListRepository wishListRepository, WLContext context)
        {
            _wishListRepository = wishListRepository;
            this._context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WishItem>))]
        public IActionResult GetWishList() 
        {
            var WishLists =_wishListRepository.GetWishItems();

            if(!ModelState.IsValid)
                return View(ModelState);

            return Ok(WishLists);
        }
    }
}
