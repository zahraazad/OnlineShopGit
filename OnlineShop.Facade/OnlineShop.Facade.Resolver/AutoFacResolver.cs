using Autofac;
using OlineShop.Logger.Interfaces;
using OlineShop.Logger.Services;
using Onlineshop.Domains.Sales.SalesService;
using Onlineshop.Domains.Sales.SalesService.Contracts;
using Onlineshop.Domains.Sales.SalesService.Interfaces;
using OnlineShop.DataLayer.DataLayer.Interfaces;
using OnlineShop.DataLayer.DataLayer.Services;
using OnlineShop.Domains.Products.ProductsRepository;
using OnlineShop.Domains.Products.ProductsService;
using OnlineShop.Domains.Products.ProductsService.Contracts;
using OnlineShop.Domains.Products.ProductsService.Interfaces;
using OnlineShop.Domains.Users.UserRepository;
using OnlineShop.Domains.Users.UserService.Contracts;
using OnlineShop.Domains.Users.UserService.Interfaces;
using OnlineShop.Domains.Users.UserService.Services;
using Onlineshop.Domains.Sales.SalesRepository;
using OnlineShop.Facade.Interfaces;
using OnlineShop.Facade.Services;

namespace OnlineShop.Facade.Resolver
{
    public class AutoFacResolver : Module
    {
        private readonly string _connectionString;
        public AutoFacResolver(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlLogger>().As<ILogger>();

            builder.RegisterType<UsersFacade>().As<IUsersFacade>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterType<ProductFacade>().As<IProductFacade>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            builder.RegisterType<SalesFacade>().As<ISalesFacade>();
            builder.RegisterType<SalesService>().As<ISalesService>();
            builder.RegisterType<SalesRepository>().As<ISalesRepository>();

            builder.RegisterType<DataLayer.DataLayer.DataLayer>().As<IDataLayer>();
            builder.RegisterType<SQLConnectionFactory>().As<ISQLConnectionFactory>().WithParameter("connectionString", _connectionString);

            base.Load(builder);
        }
    }
}
