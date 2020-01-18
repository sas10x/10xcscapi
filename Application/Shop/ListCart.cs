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

namespace Application.Shop
{
    public class ListCart
    {
        public class Query : IRequest<List<CartDto>> 
        {
            public Guid Id { get; set; }
          
        }

        public class Handler : IRequestHandler<Query, List<CartDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CartDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                //var kristan = Guid.Parse("FBB54510-2838-4C79-A9AE-08D790226499");
                
                var carts = await _context.Carts
                    .Where(s => s.Order.OrderId == request.Id)
                    .ToListAsync();
                    
                return _mapper.Map<List<Cart>, List<CartDto>>(carts);
            }

        }
    }
}