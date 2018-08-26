using OnlineShop.Domains.Products.ProductModel;
using System.Collections.Generic;

namespace OnlineShop.Domains.Products.ProductsService.Contracts
{
    public interface IProductRepository
    {
        int AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int Id);
        Product GetProductInfo(int Id);
        List<Product> GetAllProduct(int? GroupId, int? UserId);
        List<ProductGroups> GetProductGroups();
    }
}
