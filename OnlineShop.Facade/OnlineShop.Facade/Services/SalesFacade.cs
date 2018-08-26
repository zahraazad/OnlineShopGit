using AutoMapper;
using Onlineshop.Domains.Sales.SalesModel;
using Onlineshop.Domains.Sales.SalesService.Interfaces;
using OnlineShop.Facade.Interfaces;
using System;
using System.Collections.Generic;

namespace OnlineShop.Facade.Services
{
    public class SalesFacade : ISalesFacade
    {
        private readonly ISalesService _salesService;
        private readonly IProductFacade _productFacade;
        public SalesFacade(ISalesService salesService, IProductFacade productFacade)
        {
            _salesService = salesService;
            _productFacade = productFacade;
        }
        private Guid validCartKey(Guid cartKey)
        {
            if (cartKey.Equals(Guid.Empty))
            {
                return _salesService.AddCart().CartKey;
            }
            else
            {
                if (!_salesService.ValidateCartKey(cartKey))
                    return _salesService.AddCart().CartKey;
                else
                    return cartKey;
            }
        }
        public Models.CartItemsResponse GetAllCartItems(Guid cartKey)
        {
            Models.CartItemsResponse cartItemsResponse = new Models.CartItemsResponse();

            cartItemsResponse.CartKey = cartKey;
            if (_salesService.ValidateCartKey(cartKey))
                cartItemsResponse.Products = Mapper.Map<List<CartItem>, List<Models.CartItem>>(_salesService.GetAllCartItems(cartKey));
            return cartItemsResponse;
        }

        public Models.CartItemsResponse AddToCart(Models.CartItemParams cartItemParams)
        {
            Models.CartItemsResponse cartItemsResponse = new Models.CartItemsResponse();

            Guid cartKey = validCartKey(cartItemParams.CartKey);

            CartItemParams cartItem = Mapper.Map<Models.CartItemParams, CartItemParams>(cartItemParams);
            cartItem.CartKey = cartKey;
            cartItemsResponse.CartKey = cartKey;
            cartItemsResponse.Products = Mapper.Map<List<CartItem>, List<Models.CartItem>>(_salesService.AddToCart(cartItem));
            return cartItemsResponse;
        }

        public Models.CartItemsResponse RemoveFromCart(Models.CartItemParams cartItemParams)
        {
            CartItemParams cartItem = Mapper.Map<Models.CartItemParams, CartItemParams>(cartItemParams);
            Models.CartItemsResponse cartItemsResponse = new Models.CartItemsResponse();
            cartItemsResponse.CartKey = cartItemParams.CartKey;
            cartItemsResponse.Products = Mapper.Map<List<CartItem>, List<Models.CartItem>>(_salesService.RemoveFromCart(cartItem));
            return cartItemsResponse;
        }

        public Models.DetailedCartItemsResponse GetAllDetailedCartItems(Guid cartKey)
        {
            Models.DetailedCartItemsResponse cartItemsResponse = new Models.DetailedCartItemsResponse();

            cartItemsResponse.CartKey = cartKey;
            if (_salesService.ValidateCartKey(cartKey))
                cartItemsResponse.Products = Mapper.Map<List<DetailedCartItems>, List<Models.DetailedCartItems>>(_salesService.GetAllDetailedCartItems(cartKey));
            return cartItemsResponse;
        }

        public Models.OrderResponse PlaceOrder(Models.OrderParams orderParams)
        {
            if (_salesService.ValidateCartKey(orderParams.CartKey))
            {
                Models.OrderResponse orderResponse = new Models.OrderResponse();
                orderResponse.CartKey = orderParams.CartKey;
                OrderParams orderParamsModel = Mapper.Map<Models.OrderParams, OrderParams>(orderParams);
                orderResponse.Order = Mapper.Map<Order, Models.Order>(_salesService.PlaceOrder(orderParamsModel));
                return orderResponse;
            }
            else throw new ApplicationException($"Shopping cart with key: {orderParams.CartKey} is not valid any more.");
        }
    }
}
