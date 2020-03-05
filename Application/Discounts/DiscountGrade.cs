using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Discounts
{
    public class DiscountGrade
    {
        public class Query : IRequest<List<DiscountDto>>
        {
            public long Id { get; set; }
        }   

        public class Handler : IRequestHandler<Query, List<DiscountDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<DiscountDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var discounts = await _context.Discounts
                    .Where(s => s.VarGrade.VarGradeId == request.Id)
                    .OrderByDescending(s => s.DiscountId)
                    .Take(1)
                    .ToListAsync();
                if (discounts == null)
                            throw new RestException(HttpStatusCode.NotFound, new{discount = "Not found"});
                return _mapper.Map<List<Discount>, List<DiscountDto>>(discounts);
            }
        }
    }
}