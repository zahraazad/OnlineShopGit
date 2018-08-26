using Onlineshop.Domains.Sales.SalesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlineshop.Domains.Sales.SalesService.Interfaces
{
    public interface ISalesService
    {
        ShoppingCart AddCart();
        List<CartItem> AddToCart(CartItemParams CartProdauct);
        List<CartItem> RemoveFromCart(CartItemParams CartParams);
        List<CartItem> GetAllCartItems(Guid cartKey);
        bool ValidateCartKey(Guid cartKey);
        List<DetailedCartItems> GetAllDetailedCartItems(Guid cartKey);
        Order PlaceOrder(OrderParams orderParamsModel);
    }
}
