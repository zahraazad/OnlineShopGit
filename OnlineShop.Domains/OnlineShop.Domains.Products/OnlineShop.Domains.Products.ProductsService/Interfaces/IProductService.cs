using OnlineShop.Domains.Products.ProductModel;
using System.Collections.Generic;

namespace OnlineShop.Domains.Products.ProductsService.Interfaces
{
    public interface IProductService
    {
        int AddProduct(Product product);
        Product UpdateProduct(Product product);
        void DeleteProduct(int Id);
        Product GetProductInfo(int Id);
        List<Product> GetAllProduct(int? GroupId, int? UserId);
        List<ProductGroups> GetProductGroups();
    }
}
