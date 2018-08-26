using AutoMapper;
using OnlineShop.Domains.Products.ProductsService.Interfaces;
using OnlineShop.Domains.Users.UserService.Interfaces;
using OnlineShop.Facade.Interfaces;
using OnlineShop.Domains.Products.ProductModel;
using System;
using System.Collections.Generic;

namespace OnlineShop.Facade.Services
{
    public class ProductFacade : IProductFacade
    {
        #region Fiels
        private readonly IProductService _productService;
        private readonly IUserService _userFacade;
        #endregion
        #region Counstructor
        public ProductFacade(IProductService productService, IUserService userFacade)
        {
            _productService = productService;
            _userFacade = userFacade;
        }
        #endregion
        #region PrivateMethods
        private bool IsUserAuthorisedToModifyProduct(string sessionId, int productId)
        {
            var userId = _userFacade.getLoggedOnUserId(sessionId);
            Product product = _productService.GetProductInfo(productId);
            return product.OwnerId == userId;
        }
        #endregion
        #region PublicMethods
        #region AddProduct
        public int AddProduct(string SessionId, Models.AddProductParams productParams)
        {
            if (_userFacade.ValidateKey(SessionId))
            {
                var userId = _userFacade.getLoggedOnUserId(SessionId);
                Product product = Mapper.Map<Models.AddProductParams, Product>(productParams);
                product.OwnerId = userId;
                return _productService.AddProduct(product);
            }
            else
                throw new UnauthorizedAccessException();
        }
        #endregion
        #region DeleteProduct
        public void DeleteProduct(string SessionId, int Id)
        {
            if (_userFacade.ValidateKey(SessionId))
            {
                if (IsUserAuthorisedToModifyProduct(SessionId, Id))
                {
                    _productService.DeleteProduct(Id);
                }
                else
                    throw new UnauthorizedAccessException();
            }
            else
                throw new UnauthorizedAccessException();
        }
        #endregion
        #region GetAllProduct
        public Models.ProductListResponse GetAllProduct(string SessionId, int? GroupId)
        {
            Models.ProductListResponse productListResponse = new Models.ProductListResponse();

            if (_userFacade.ValidateKey(SessionId))
            {
                var userId = _userFacade.getLoggedOnUserId(SessionId);
                productListResponse.Products = Mapper.Map<List<Product>, List<Models.Product>>(_productService.GetAllProduct(GroupId, userId));
            }
            else
                productListResponse.Products = Mapper.Map<List<Product>, List<Models.Product>>(_productService.GetAllProduct(GroupId, null));
            return productListResponse;
        }
        #endregion
        #region GetProductGroups
        public Models.ProductGroupListResponse GetProductGroups()
        {
            List<ProductGroups> productGroups = _productService.GetProductGroups();
            Models.ProductGroupListResponse productGroupsResponse = new Models.ProductGroupListResponse()
            {
                ProductGroups = Mapper.Map<List<ProductGroups>, List<Models.ProductGroup>>(productGroups)
            };
            return productGroupsResponse;
        }
        #endregion
        #region GetProductInfo
        public Models.Product GetProductInfo(int Id)
        {
            Product product = _productService.GetProductInfo(Id);
            return Mapper.Map<Product, Models.Product>(product);
        }
        #endregion
        #region UpdateProduct
        public Models.Product UpdateProduct(string SessionId, Models.UpdateProductParams productParams)
        {
            if (_userFacade.ValidateKey(SessionId))
            {
                if (IsUserAuthorisedToModifyProduct(SessionId, productParams.Id))
                {
                    Product productModel = _productService.UpdateProduct(Mapper.Map<Models.UpdateProductParams, Product>(productParams));
                    return Mapper.Map<Product, Models.Product>(productModel);
                }
                else throw new UnauthorizedAccessException();
            }
            else
                throw new UnauthorizedAccessException();
        }
        #endregion
        #endregion
    }
}
