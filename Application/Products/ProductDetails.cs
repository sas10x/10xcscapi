using System;
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

namespace Application.Products
{
    public class ProductDetails
    {
        public class Query : IRequest<ProductDto>
        {
            public Query(long? grade, long? diameter, long? length)
            {
               Grade = grade;
               Diameter = diameter;
               Length = length;
            }
            public long? Grade { get; set; }
            public long? Diameter { get; set; }
            public long? Length { get; set; }
        }   

        public class Handler : IRequestHandler<Query, ProductDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ProductDto> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.Grade != null)
                {

                }
                var product = await _context.Products
                    .Where(s => s.VarGrade.VarGradeId == request.Grade)
                    .Where(s => s.VarLength.VarLengthId == request.Length)
                    .Where(s => s.VarDiameter.VarDiameterId == request.Diameter)
                    .FirstOrDefaultAsync();
                if (product == null)
                            throw new RestException(HttpStatusCode.NotFound, new{product = "Not found"});
                var productToReturn = _mapper.Map<Product, ProductDto>(product);

                return productToReturn;
            }
        }
    }
}