using AutoMapper;
using Domain;

namespace Application.Shop
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Cart, CartDto>()
                .ForMember(d => d.Product, o => o.MapFrom(s => s.Product.ProductId))
                .ForMember(d => d.Order, o => o.MapFrom(s => s.Order.OrderId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Product.Price));
        }
    }
}