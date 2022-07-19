using AutoMapper;
using ShoppingCart.Entities.DTOs.Cart;
using ShoppingCart.Entities.DTOs.CartItem;
using ShoppingCart.Entities.Models;

namespace ShoppingCart.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CartItem, CartItemShortDto>();
            CreateMap<CartItem, CartItemDto>();
            CreateMap<CartItemCreationDto, CartItem>();
            CreateMap<Cart, CartDto>();
        }
    }
}
