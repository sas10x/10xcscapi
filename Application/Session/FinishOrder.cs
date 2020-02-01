using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Session
{
    public class FinishOrder
    {
        public class Command : IRequest
        {
            public Guid OrderId { get; set; }
            public decimal Amount { get; set; }
            
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
               _context = context;  
               _userAccessor = userAccessor; 
            }
        
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var exist = await _context.Orders.FindAsync(request.OrderId);
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == _userAccessor.GetCurrentUsername());
                exist.User = user;
                exist.Amount = request.Amount;
                exist.Date = DateTime.Now;
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }   
    }
}