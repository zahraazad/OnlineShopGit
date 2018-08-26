using OnlineShop.Facade.Models;
using System;

namespace OnlineShop.Facade.Interfaces
{
    public interface ISalesFacade
    {
        CartItemsResponse AddToCart(CartItemParams toCartParams);
        CartItemsResponse RemoveFromCart(CartItemParams CartParams);
        CartItemsResponse GetAllCartItems(Guid toCartParams);
        DetailedCartItemsResponse GetAllDetailedCartItems(Guid cartKey);
        OrderResponse PlaceOrder(OrderParams orderParams);
    }
}