﻿using ShoppingCart.Entities.DTOs.Cart;

namespace ShoppingCart.Contracts.IServices
{
    public interface ICartService
    {
        Task<CartDto?> GetCartAsync(int cartId, bool trackChanges);
        Task<bool> CancelCartAsync(int cartId);
    }
}
