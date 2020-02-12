using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Session
{
    public class ListOrder
    {
        public class Query : IRequest<List<OrderDto>> { }

        public class Handler : IRequestHandler<Query, List<OrderDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor; 
            }

            public async Task<List<OrderDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                // var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                // var attendance = await _context.UserActivities.SingleOrDefaultAsync(x => x.ActivityId == activity.Id && x.AppUserId == user.Id);

                // var carts = await _context.Carts
                //     .Where(s => s.Order.OrderId == request.Id)
                //     .ToListAsync();
                    
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                // var orders = await _context.Orders.ToListAsync(x => x.UserId == user.Id);
                var orders = await _context.Orders
                    .Where(s => s.User.Id == user.Id)
                    .ToListAsync();
                return _mapper.Map<List<Order>, List<OrderDto>>(orders);
                // return orders;
            }

        }
    }
}