using OnlineShop.DataLayer.DataLayer.Interfaces;
using OnlineShop.Domains.Products.ProductModel;
using OnlineShop.Domains.Products.ProductsService.Contracts;
using System.Collections.Generic;

namespace OnlineShop.Domains.Products.ProductsRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataLayer _dataLayer;
        public ProductRepository(IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        public int AddProduct(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (var prop in product.GetType().GetProperties())
            {
                if (prop.Name != "Id")
                    parameters.Add(prop.Name, prop.GetValue(product));
            }
            return _dataLayer.AddItem<int>("sp_OnlineShop_AddProduct", parameters);
        }

        public void UpdateProduct(Product product)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            foreach (var prop in product.GetType().GetProperties())
            {
                parameters.Add(prop.Name, prop.GetValue(product));
            }
            _dataLayer.ExecuteQuery("sp_OnlineShop_UpdateProduct", parameters);
        }

        public void DeleteProduct(int Id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Id", Id);
            _dataLayer.DeleteItem("sp_OnlineShop_DeleteProduct", parameters);
        }

        public Product GetProductInfo(int Id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Id", Id);
            return _dataLayer.GetItem<Product>("sp_OnlineShop_GetProductInfo", parameters);
        }

        public List<Product> GetAllProduct(int? GroupId, int? UserId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("GroupId", GroupId);
            parameters.Add("UserId", UserId);
            return _dataLayer.GetList<Product>("sp_OnlineShop_GetAllProduct", parameters);
        }

        public List<ProductGroups> GetProductGroups()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            return _dataLayer.GetList<ProductGroups>("sp_OnlineShop_GetProductGroups", parameters);
        }
    }
}
