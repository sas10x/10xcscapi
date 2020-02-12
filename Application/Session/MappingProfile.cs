using AutoMapper;
using Domain;
namespace Application.Session
{
    public class MappingProfile: Profile
    {
         public MappingProfile()
        {
           CreateMap<Order, OrderDto>();
        }
    }
}