using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Application.Common.Abstractions;
using ZINTEGRUJEMY.Application.Result;
using ZINTEGRUJEMY.Domain.DTO;
using ZINTEGRUJEMY.Domain.ReadModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZINTEGRUJEMY.Application.Features.Product.Queries
{
    public class GetProductQuery : IRequest<Result<ProductSearchResult>>
    {
        public string SKU { get; set; }
    }

    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(v => v.SKU)
                .NotNull().NotEmpty().WithMessage("SKU produktu jest wymagane!");
        }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<ProductSearchResult>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetProductQueryHandler(IMediator mediator, IMapper mapper, IApplicationDbContext context)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<ProductSearchResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            // get data from 3 tables
            var product = _context.Products.FirstOrDefault(x => x.SKU == request.SKU);
            var inventory = _context.Inventories.FirstOrDefault(x => x.SKU == request.SKU);
            var price = _context.Prices.FirstOrDefault(x => x.SKU == request.SKU);

            // if null return 404
            if (product == null)
                return Result<ProductSearchResult>.NotFound();

            // map to return model
            var result = _mapper.Map<ProductSearchResult>(product);

            // if not null complete data
            if (inventory != null)
            {
                result.Qty = inventory.Qty;
                result.Unit = inventory.Unit;
                result.ShippingCost = inventory.ShippingCost;
            }

            // if not null complete the data
            if (price != null)
                result.NettPrice = price.NettPrice;


            return Result<ProductSearchResult>.Success(result);
        }
    }
}
