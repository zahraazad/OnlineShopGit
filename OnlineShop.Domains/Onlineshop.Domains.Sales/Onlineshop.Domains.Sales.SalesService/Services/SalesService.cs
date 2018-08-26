using Onlineshop.Domains.Sales.SalesModel;
using Onlineshop.Domains.Sales.SalesService.Contracts;
using Onlineshop.Domains.Sales.SalesService.Interfaces;
using System;
using System.Collections.Generic;

namespace Onlineshop.Domains.Sales.SalesService
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly int _CartValidationHours;
        public SalesService(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
            _CartValidationHours = 5;
        }
        public ShoppingCart AddCart()
        {
            try
            {
                return _salesRepository.AddCart(_CartValidationHours);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<CartItem> AddToCart(CartItemParams CartItem)
        {
            try
            {
                List<CartItem> cartItems = _salesRepository.GetAllCartItems(CartItem.CartKey);
                bool exists = false;
                foreach (var item in cartItems)
                {
                    if (item.ProductId == CartItem.ProductId)
                        exists = true;
                }
                if (exists)
                    return _salesRepository.IncreaseItemQuantityInCart(CartItem);
                return _salesRepository.AddToCart(CartItem);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CartItem> GetAllCartItems(Guid cartKey)
        {
            try
            {
                return _salesRepository.GetAllCartItems(cartKey);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DetailedCartItems> GetAllDetailedCartItems(Guid cartKey)
        {
            try
            {
                return _salesRepository.GetAllDetailedCartItems(cartKey);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Order PlaceOrder(OrderParams orderParamsModel)
        {
            try
            {
                return _salesRepository.PlaceOrder(orderParamsModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CartItem> RemoveFromCart(CartItemParams CartItem)
        {
            try
            {
                return _salesRepository.RemoveFromCart(CartItem);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ValidateCartKey(Guid cartKey)
        {
            try
            {
                ShoppingCart cart = _salesRepository.ValidateCartKey(cartKey);
                return (cart == null ? false : (cart.ExpiryDateTime > DateTime.Now && !cart.IsPayed));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
