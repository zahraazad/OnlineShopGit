using Onlineshop.Domains.Sales.SalesModel;
using Onlineshop.Domains.Sales.SalesService.Contracts;
using OnlineShop.DataLayer.DataLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace Onlineshop.Domains.Sales.SalesRepository
{
    public class SalesRepository : ISalesRepository
    {
        private readonly IDataLayer _dataLayer;
        public SalesRepository(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }
        public ShoppingCart AddCart(int CartValidationHours)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CartValidationHours", CartValidationHours);
            return _dataLayer.AddItem<ShoppingCart>("sp_OnlineShop_AddCart", parameters);
        }

        public List<CartItem> AddToCart(CartItemParams cartItem)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (var prop in cartItem.GetType().GetProperties())
            {
                parameters.Add(prop.Name, prop.GetValue(cartItem));
            }
            return _dataLayer.GetList<CartItem>("sp_OnlineShop_AddProductToCart", parameters);
        }

        public List<CartItem> GetAllCartItems(Guid CartKey)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CartKey", CartKey);
            return _dataLayer.GetList<CartItem>("sp_OnlineShop_GetAllCartItems", parameters);
        }

        public List<DetailedCartItems> GetAllDetailedCartItems(Guid CartKey)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CartKey", CartKey);
            return _dataLayer.GetList<DetailedCartItems>("sp_OnlineShop_GetAllDetailesCartItems", parameters);
        }

        public List<CartItem> IncreaseItemQuantityInCart(CartItemParams cartItem)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (var prop in cartItem.GetType().GetProperties())
            {
                parameters.Add(prop.Name, prop.GetValue(cartItem));
            }
            return _dataLayer.GetList<CartItem>("sp_OnlineShop_IncreaseItemQuantityInCart", parameters);
        }

        public Order PlaceOrder(OrderParams orderParamsModel)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (var prop in orderParamsModel.GetType().GetProperties())
            {
                parameters.Add(prop.Name, prop.GetValue(orderParamsModel));
            }
            return _dataLayer.GetItem<Order>("sp_OnlineShop_PlaceOrder", parameters);
        }

        public List<CartItem> RemoveFromCart(CartItemParams cartItem)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (var prop in cartItem.GetType().GetProperties())
            {
                parameters.Add(prop.Name, prop.GetValue(cartItem));
            }
            return _dataLayer.GetList<CartItem>("sp_OnlineShop_RemoveProductFromCart", parameters);
        }

        public ShoppingCart ValidateCartKey(Guid CartKey)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CartKey", CartKey);
            return _dataLayer.AddItem<ShoppingCart>("sp_OnlineShop_GetCartByKey", parameters);
        }
    }
}
