using System.Linq;
using AutoMapper;
using Domain;
namespace Application.Discounts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Discount, DiscountDto>()
                .ForMember(d => d.VarGrade, o => o.MapFrom(s => s.VarGrade.Name));
            
        }
    }
}