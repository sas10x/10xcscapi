using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Discounts
{
    public class CreateDiscount
    {
        public class Command : IRequest<Unit>
        {
            // public long DiscountId { get; set; }
            public decimal Pursinto { get; set; }
            public long Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
               _context = context;   
            }
        
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var products = await _context.Products
                    .Where(s => s.VarGrade.VarGradeId == request.Id)
                    .ToListAsync();
                foreach (Product items in products)
                { 
                    var percent = request.Pursinto / 100;
                    items.Price = items.BasePrice - items.BasePrice * percent;
                }
                var grade = await _context.VarGrades.FindAsync(request.Id);
                var discount = new Discount
                {
                    Date = DateTime.Now,
                    Pursinto = request.Pursinto,
                    VarGrade = grade
                };
                _context.Discounts.Add(discount);
                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                       throw new Exception("Problem saving changes");
            }
        }  
    }
}