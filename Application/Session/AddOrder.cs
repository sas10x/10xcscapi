using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Session
{
    public class AddOrder
    {
      public class Command : IRequest<Order>
        {
            public Guid OrderId { get; set; }
        }
        public class Handler : IRequestHandler<Command, Order>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
               _context = context;   
            }
        
            public async Task<Order> Handle(Command request, CancellationToken cancellationToken)
            {
                var order = new Order
                {
                    Date = DateTime.Now
                };
                _context.Orders.Add(order);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return order;
                       throw new Exception("Problem saving changes");
            }
        }  
    }
}