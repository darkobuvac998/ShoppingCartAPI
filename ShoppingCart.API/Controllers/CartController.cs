using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Contracts.IServices;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]/{cartId:int}")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IServiceManager service;

        public CartController(IServiceManager serviceManager)
        {
            service = serviceManager;
        }

        [HttpGet]
        [Authorize(Policy = "ReadAccess")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCartAsync(int cartId)
        {
            var cart = await service.CartService.GetCartAsync(cartId, false);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPut("cancel")]
        [Authorize(Policy = "FullAccess")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelCartAsync(int cartId)
        {
            await service.CartService.CancelCartAsync(cartId);
            return NoContent();
        }

        [HttpPost("submit")]
        [Authorize(Policy = "FullAccess")]
        public async Task SubmitCart(int cartId)
        {
            // TODO: Data preparation and sending goes here.
        }
    }
}
