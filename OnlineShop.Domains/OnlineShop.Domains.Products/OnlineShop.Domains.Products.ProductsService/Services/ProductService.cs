using OnlineShop.Domains.Products.ProductModel;
using OnlineShop.Domains.Products.ProductsService.Contracts;
using OnlineShop.Domains.Products.ProductsService.Interfaces;
using System;
using System.Collections.Generic;

namespace OnlineShop.Domains.Products.ProductsService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(Product product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException();
                return _productRepository.AddProduct(product);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteProduct(int Id)
        {
            try
            {
                _productRepository.DeleteProduct(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetAllProduct(int? GroupId, int? UserId)
        {
            try
            {
                return _productRepository.GetAllProduct(GroupId, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductGroups> GetProductGroups()
        {
            return _productRepository.GetProductGroups();
        }

        public Product GetProductInfo(int Id)
        {
            try
            {
                return _productRepository.GetProductInfo(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product UpdateProduct(Product product)
        {
            try
            {
                if (product == null)
                    throw new ArgumentNullException();
                _productRepository.UpdateProduct(product);
                return _productRepository.GetProductInfo(product.Id);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
