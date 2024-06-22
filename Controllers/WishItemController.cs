using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIWishList.Data;
using WebAPIWishList.Dto;
using WebAPIWishList.Interfaces;
using WebAPIWishList.Models;

namespace WebAPIWishList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishItemController : Controller
    {
        private readonly IWishListRepository _wishListRepository;
        private readonly IMapper _mapper;
        
        public WishItemController(IWishListRepository wishListRepository, IMapper mapper)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WishItem>))]
        public IActionResult GetWishList()
        {
            var WishLists = _mapper.Map<List<WishItemDto>>(_wishListRepository.GetWishItems());

            if (!ModelState.IsValid)
                return View(ModelState);

            return Ok(WishLists);
        }

        [HttpGet("{wishId}")]
        [ProducesResponseType(200, Type = typeof(WishItem))]
        [ProducesResponseType(400)]
        public IActionResult GetWishListItem(int wishId)
        {
            if (!_wishListRepository.WishItemExists(wishId))
                return NotFound();

            var wishItem = _mapper.Map<WishItemDto>(_wishListRepository.GetWishItem(wishId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(wishItem);
        }

    }
}
