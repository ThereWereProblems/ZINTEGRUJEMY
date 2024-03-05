using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Application.Common.Abstractions;
using ZINTEGRUJEMY.Application.Result;
using ZINTEGRUJEMY.Domain.DTO;

namespace ZINTEGRUJEMY.Application.Features.File.Queries
{
    public class GetPricesFromFileQuery : IRequest<Result<List<PriceDTO>>>
    {
        public string FileName { get; set; }
    }

    public class GetPricesFromFileQueryValidator : AbstractValidator<GetPricesFromFileQuery>
    {
        public GetPricesFromFileQueryValidator()
        {
            RuleFor(v => v.FileName)
                .NotNull().NotEmpty().WithMessage("Nazwa pliku jest wymagana!");
        }
    }

    public class GetPricesFromFileQueryHandler : IRequestHandler<GetPricesFromFileQuery, Result<List<PriceDTO>>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISorceFileHandlerFactory<PriceDTO> _sorceFileHandlerFactory;

        public GetPricesFromFileQueryHandler(IMediator mediator, IMapper mapper, ISorceFileHandlerFactory<PriceDTO> sorceFileHandlerFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            _sorceFileHandlerFactory = sorceFileHandlerFactory;
        }

        public async Task<Result<List<PriceDTO>>> Handle(GetPricesFromFileQuery request, CancellationToken cancellationToken)
        {
            // find handler
            var handler = await _sorceFileHandlerFactory.GetInstance(request.FileName);

            if (handler == null)
                return Result<List<PriceDTO>>.Error($"Nie można odczytać pliku {request.FileName}!");

            // combine path
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", request.FileName);

            // get list of prices
            var listOfPrices = await handler.Handle(path, false);

            var result = listOfPrices.Where(x => x.IsSuccessfullCreated).ToList();

            var lenghtAll = listOfPrices.Count;
            var lenghtSuccessfullReaded = result.Count;

            if (lenghtAll - lenghtSuccessfullReaded > 0)
            {
                // TODO - some log
            }

            return Result<List<PriceDTO>>.Success(result);
        }
    }
}
