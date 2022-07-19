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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetCart(int cartId)
        {
            var cart = await service.CartService.GetCartAsync(cartId, false);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPut("cancel")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelCart(int cartId)
        {
            await service.CartService.CancelCart(cartId);
            return Ok();
        }

        [HttpPost("submit")]
        public async Task SubmitCart(int cartId)
        {
            // TODO: Data preparation and sending goes here
        }
    }
}
