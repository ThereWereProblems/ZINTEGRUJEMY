using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Application.Common.Abstractions;
using ZINTEGRUJEMY.Application.Features.File.Commands;
using ZINTEGRUJEMY.Application.Result;
using ZINTEGRUJEMY.Domain.DTO;

namespace ZINTEGRUJEMY.Application.Features.Product.Queries
{
    public class GetProductsFromFileQuery : IRequest<Result<List<ProductDTO>>>
    {
        public string FileName { get; set; }
    }

    public class GetProductsFromFileQueryValidator : AbstractValidator<GetProductsFromFileQuery>
    {
        public GetProductsFromFileQueryValidator()
        {
            RuleFor(v => v.FileName)
                .NotNull().NotEmpty().WithMessage("Nazwa pliku jest wymagana!");
        }
    }

    public class GetProductsFromFileQueryHandler : IRequestHandler<GetProductsFromFileQuery, Result<List<ProductDTO>>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISorceFileHandlerFactory<ProductDTO> _sorceFileHandlerFactory;

        public GetProductsFromFileQueryHandler(IMediator mediator, IMapper mapper, ISorceFileHandlerFactory<ProductDTO> sorceFileHandlerFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            _sorceFileHandlerFactory = sorceFileHandlerFactory;
        }

        public async Task<Result<List<ProductDTO>>> Handle(GetProductsFromFileQuery request, CancellationToken cancellationToken)
        {
            // find handler
            var handler = await _sorceFileHandlerFactory.GetInstance(request.FileName);

            if (handler == null)
                return Result<List<ProductDTO>>.Error($"Nie można odczytać pliku {request.FileName}!");

            // combine path
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", request.FileName);

            // get list of products
            var listOfProducts = await handler.Handle(path);

            var result = listOfProducts.Where(x => x.IsSuccessfullCreated).ToList();

            var lenghtAll = listOfProducts.Count;
            var lenghtSuccessfullReaded = result.Count;

            if (lenghtAll - lenghtSuccessfullReaded > 0)
            {
                // TODO - some log
            }

            return Result<List<ProductDTO>>.Success(result);
        }
    }
}
