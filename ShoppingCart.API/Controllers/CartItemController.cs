using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Contracts.IServices;
using ShoppingCart.Entities.Data;
using ShoppingCart.Entities.DTOs.CartItem;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.API.Controllers
{
    [Route("api/Cart/{cartId:int}/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ShoppingCartDatabaseContext dbContext;
        private readonly IMapper mapper;
        private readonly IServiceManager service;

        public CartItemController(ShoppingCartDatabaseContext context, IMapper autoMapper, IServiceManager serviceManager)
        {
            dbContext = context;
            mapper = autoMapper;
            service = serviceManager;
        }

        [HttpGet("{itemId:int}", Name = "GetCartItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCartItem(int cartId, int itemId)
        {
            var item = await service.CartItemService.GetCartItemAsync(cartId, itemId, false);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCartItem([FromBody] CartItemCreationDto cartItemDto, int cartId)
        {
            if (cartItemDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cart = await dbContext.Carts.FindAsync(cartId);
            if (cart == null)
            {
                return NotFound();
            }

            var cartItem = mapper.Map<CartItem>(cartItemDto);
            cartItem.CartId = cartId;
            cartItem.TimeCreated = DateTime.UtcNow;
            cartItem.TimeUpdated = DateTime.UtcNow;

            await dbContext.CartItems.AddAsync(cartItem);
            await dbContext.SaveChangesAsync();

            var cartDtoResult = mapper.Map<CartItemDto>(cartItem);

            return CreatedAtRoute("GetCartItem", new { cartId = cartId, itemId = cart.CartId }, cartDtoResult);
        }

        [HttpDelete("{itemId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCartItem(int cartId, int itemId)
        {
            var item = await dbContext.CartItems.Where(i => i.CartId == cartId && i.CartItemId == itemId).FirstOrDefaultAsync();
            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                dbContext.CartItems.Remove(item);
                await dbContext.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
