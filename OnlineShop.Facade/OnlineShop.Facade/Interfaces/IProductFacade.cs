using OnlineShop.Facade.Models;
using System.Collections.Generic;

namespace OnlineShop.Facade.Interfaces
{
    public interface IProductFacade
    {
        int AddProduct(string SessionId, AddProductParams productParams);
        Product UpdateProduct(string SessionId, UpdateProductParams productParams);
        void DeleteProduct(string SessionId, int Id);
        Product GetProductInfo(int Id);
        ProductListResponse GetAllProduct(string SessionId, int? GroupId);
        ProductGroupListResponse GetProductGroups();
    }
}
