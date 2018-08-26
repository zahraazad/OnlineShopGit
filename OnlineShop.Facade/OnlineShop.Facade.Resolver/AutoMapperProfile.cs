using AutoMapper;
using OnlineShop.Domains.Users.UsersModel;
using OnlineShop.Domains.Products.ProductModel;
using System;
using Onlineshop.Domains.Sales.SalesModel;

namespace OnlineShop.Facade.Resolver
{
    public class AutoMapperProfile : Profile
    {
        public static void config()
        {
            Mapper.Initialize(cnfg =>
            {
                cnfg.CreateMap<User, Models.User>();
                cnfg.CreateMap<Models.User, User>();
                cnfg.CreateMap<Product, Models.Product>();
                cnfg.CreateMap<Models.Product, Product>();
                cnfg.CreateMap<Models.UpdateProductParams, Product>();
                cnfg.CreateMap<Models.AddProductParams, Product>()
                .ForMember(src => src.OwnerId, opt => opt.MapFrom(src => 0));

                cnfg.CreateMap<CartItem, Models.CartItem>();
                cnfg.CreateMap<Models.CartItemParams, CartItemParams>();
            });
        }
    }
}
