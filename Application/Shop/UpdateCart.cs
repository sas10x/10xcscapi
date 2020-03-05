using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Shop
{
    public class UpdateCart
    {
        public class Command : IRequest
        {
            public long CartId { get; set; }
            public long Quantity { get; set; }
            public decimal Total { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
               _context = context;   
            }
        
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {   
                var exist = await _context.Carts.FindAsync(request.CartId);
                if (exist == null)
                {
                    throw new Exception((request.CartId).ToString());
                }
                exist.Quantity = request.Quantity;
                exist.Total = request.Total;
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}