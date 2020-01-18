using System;
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
    public class AddressCities
    {
        public class Query : IRequest<List<CityDto>> 
        {
            public long Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<CityDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cities = await _context.Citys
                    .Where(s => s.Province.ProvinceId == request.Id)
                    .ToListAsync();
                return _mapper.Map<List<City>, List<CityDto>>(cities);
            }

        }
    }
}