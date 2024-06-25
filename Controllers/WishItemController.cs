using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPIWishList.Data;
using WebAPIWishList.Dto;
using WebAPIWishList.Models;
using WebAPIWishList.Repository.Interfaces;

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
            return Ok(WishLists);
        }

        [HttpGet("{wishId}")]
        [ProducesResponseType(200, Type = typeof(WishItem))]
        [ProducesResponseType(400)]
        public IActionResult GetWishListItem(int wishId)
        {
            var wishItem = _mapper.Map<WishItemDto>(_wishListRepository.GetWishItem(wishId));
            return Ok(wishItem);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateWishItem([FromBody] WishItem wishItemCreate)
        {
            var wishItemMap = _mapper.Map<WishItem>(wishItemCreate);
            _wishListRepository.CreateWishItem(wishItemMap);
            return NoContent();
        }

        [HttpPut("{wishItemId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateWishItem(int wishItemId, [FromBody]WishItem updateWishItem)
        {
            var wishItemMap = _mapper.Map<WishItem>(updateWishItem);
            _wishListRepository.UpdateWishItem(wishItemMap, wishItemId);
            return NoContent();
        }


        [HttpDelete("{wishItemId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteWishItem(int wishItemId) 
        {
            var wishItemToDelete = _wishListRepository.GetWishItem(wishItemId);
            _wishListRepository.DeleteWishItem(wishItemToDelete);
            return NoContent();
        }


    }
}
