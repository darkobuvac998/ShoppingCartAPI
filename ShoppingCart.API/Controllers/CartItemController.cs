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

        [HttpGet("{itemId:int}", Name = "GetCartItem")]
        [Authorize(Policy = "ReadAccess")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartItemAsync(int cartId, int itemId)
        {
            var item = await service.CartItemService.GetCartItemAsync(cartId, itemId, false);
            var name = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "https://example.com/email")?.Value;

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

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

        [HttpDelete("{itemId:int}")]
        [Authorize(Policy = "FullAccess")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveCartItemAsync(int cartId, int itemId)
        {
            await service.CartItemService.RemoveCartItemAsync(cartId, itemId);
            return NoContent();
        }
    }
}
