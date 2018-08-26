using Onlineshop.Domains.Sales.SalesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlineshop.Domains.Sales.SalesService.Contracts
{
    public interface ISalesRepository
    {
        ShoppingCart AddCart(int CartValidationHours);
        List<CartItem> AddToCart(CartItemParams cartItem);
        List<CartItem> RemoveFromCart(CartItemParams cartItem);
        List<CartItem> GetAllCartItems(Guid cartKey);
        List<CartItem> IncreaseItemQuantityInCart(CartItemParams cartItem);
        ShoppingCart ValidateCartKey(Guid CartKey);
        List<DetailedCartItems> GetAllDetailedCartItems(Guid cartKey);
        Order PlaceOrder(OrderParams orderParamsModel);
    }
}
