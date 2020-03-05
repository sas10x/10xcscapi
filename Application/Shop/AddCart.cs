using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using Domain;
using Application.Errors;
using System.Net;
using AutoMapper;

namespace Application.Shop
{
    public class AddCart
    {
        public class Command : IRequest<CartDto>
        {
            public long Quantity { get; set; }
            public decimal Total { get; set; }
            public long Product { get; set; }
            public Guid Order { get; set; }

        }
        public class Handler : IRequestHandler<Command, CartDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
               _context = context;   
               _mapper = mapper;
               
            }
        
            public async Task<CartDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var prod = await _context.Products.FindAsync(request.Product);
                if (prod == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Product = "Could not find product" });
                var ord = await _context.Orders.FindAsync(request.Order);
                if (ord == null)
                    throw new RestException(HttpStatusCode.NotFound, new { Order = "Could not find session" });
                var cart = new Cart
                {
                    Quantity = request.Quantity,
                    Price = prod.Price,
                    Total = request.Total,
                    Product = prod,
                    Order = ord,
                    ProductName = prod.Name
                };
                _context.Carts.Add(cart);
                var success = await _context.SaveChangesAsync() > 0;
                var cartReturn = _mapper.Map<Cart, CartDto>(cart);
                if (success) return cartReturn;
                throw new Exception("Problem saving changes");
            }
        }
    }
}