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

        /// <summary>
        /// Get overview of a shopping cart.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns>Cart with cart items.</returns>
        /// <response code="200">Cart whit cart items.</response>
        /// <response code="404">If cart does not exists in database.</response>
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

        /// <summary>
        /// Change the cart status to canceled.
        /// </summary>
        /// <param name="cartId"></param>
        [HttpPut("cancel")]
        [Authorize(Policy = "FullAccess")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelCartAsync(int cartId)
        {
            var succeeded = await service.CartService.CancelCartAsync(cartId);
            if (succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Submits cart and send data to 3rd party system.
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpPost("submit")]
        [Authorize(Policy = "FullAccess")]
        public async Task SubmitCart(int cartId)
        {
            // TODO: Data preparation and sending goes here.
        }
    }
}
