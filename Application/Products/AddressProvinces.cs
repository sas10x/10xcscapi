using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class AddressProvinces
    {
        public class Query : IRequest<List<ProvinceDto>> { }

        public class Handler : IRequestHandler<Query, List<ProvinceDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProvinceDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var provinces = await _context.Provinces
                    .OrderBy(x => x.ProvDesc)
                    .ToListAsync();
                return _mapper.Map<List<Province>, List<ProvinceDto>>(provinces);
            }

        }
    }
}