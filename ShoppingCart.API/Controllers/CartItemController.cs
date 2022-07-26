using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.DTOs.CartItem;

namespace ShoppingCart.API.Controllers
{
    [Route("api/Cart/{cartId:int}/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly IServiceManager service;

        public CartItemController(IServiceManager serviceManager)
        {
            service = serviceManager;
        }

        /// <summary>
        /// Get cart item details.
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="itemId"></param>
        /// <returns>Cart item with all attributes</returns>
        /// <response code="404">If cart item does not exists in database.</response>
        [HttpGet("{itemId:int}", Name = "GetCartItem")]
        [Authorize(Policy = "ReadAccess")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartItemAsync(int cartId, int itemId)
        {
            var item = await service.CartItemService.GetCartItemAsync(cartId, itemId, false);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        /// <summary>
        /// Add new item to cart.
        /// </summary>
        /// <param name="cartItemDto"></param>
        /// <param name="cartId"></param>
        /// <returns>Created item with all attributes.</returns>
        /// <response code="201">If item is added successfully.</response>
        /// <response code="400">If any validation error occurs.</response>
        [HttpPost]
        [Authorize(Policy = "FullAccess")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCartItemAsync([FromBody] CartItemCreationDto cartItemDto, int cartId)
        {
            if (cartItemDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await service.CartItemService.AddCartItemAsync(cartItemDto, cartId);

            if (result != null)
            {
                return CreatedAtRoute("GetCartItem", new { cartId = cartId, itemId = result?.CartItemId }, result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Removes item from cart.
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <response code="400">If cart does not exists in database.</response>
        [HttpDelete("{itemId:int}")]
        [Authorize(Policy = "FullAccess")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveCartItemAsync(int cartId, int itemId)
        {
            var succeeded = await service.CartItemService.RemoveCartItemAsync(cartId, itemId);
            if (succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
