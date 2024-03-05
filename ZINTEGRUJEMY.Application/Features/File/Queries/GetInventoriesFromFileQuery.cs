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
    public class GetInventoriesFromFileQuery : IRequest<Result<List<InventoryDTO>>>
    {
        public string FileName { get; set; }
    }

    public class GetInventoriesFromFileQueryValidator : AbstractValidator<GetInventoriesFromFileQuery>
    {
        public GetInventoriesFromFileQueryValidator()
        {
            RuleFor(v => v.FileName)
                .NotNull().NotEmpty().WithMessage("Nazwa pliku jest wymagana!");
        }
    }

    public class GetInventoriesFromFileQueryHandler : IRequestHandler<GetInventoriesFromFileQuery, Result<List<InventoryDTO>>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ISorceFileHandlerFactory<InventoryDTO> _sorceFileHandlerFactory;

        public GetInventoriesFromFileQueryHandler(IMediator mediator, IMapper mapper, ISorceFileHandlerFactory<InventoryDTO> sorceFileHandlerFactory)
        {
            _mediator = mediator;
            _mapper = mapper;
            _sorceFileHandlerFactory = sorceFileHandlerFactory;
        }

        public async Task<Result<List<InventoryDTO>>> Handle(GetInventoriesFromFileQuery request, CancellationToken cancellationToken)
        {
            // find handler
            var handler = await _sorceFileHandlerFactory.GetInstance(request.FileName);

            if (handler == null)
                return Result<List<InventoryDTO>>.Error($"Nie można odczytać pliku {request.FileName}!");

            // combine path
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", request.FileName);

            // get list of inventories
            var listOfInventories = await handler.Handle(path);

            var result = listOfInventories.Where(x => x.IsSuccessfullCreated).ToList();

            var lenghtAll = listOfInventories.Count;
            var lenghtSuccessfullReaded = result.Count;

            if (lenghtAll - lenghtSuccessfullReaded > 0)
            {
                // TODO - some log
            }

            return Result<List<InventoryDTO>>.Success(result);
        }
    }
}
