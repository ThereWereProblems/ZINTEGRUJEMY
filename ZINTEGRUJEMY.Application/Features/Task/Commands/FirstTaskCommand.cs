using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Application.Common.Abstractions;
using ZINTEGRUJEMY.Application.Features.File.Commands;
using ZINTEGRUJEMY.Application.Features.File.Queries;
using ZINTEGRUJEMY.Application.Features.Product.Queries;
using ZINTEGRUJEMY.Application.Result;

namespace ZINTEGRUJEMY.Application.Features.Task.Commands
{
    public class FirstTaskCommand : IRequest<Result<bool>>
    {

    }

    public class FirstTaskCommandHandler : IRequestHandler<FirstTaskCommand, Result<bool>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public FirstTaskCommandHandler(IMediator mediator, IMapper mapper, IApplicationDbContext applicationDbContext)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = applicationDbContext;
        }

        public async Task<Result<bool>> Handle(FirstTaskCommand request, CancellationToken cancellationToken)
        {
            // download and save Products.csv file
            var result = await _mediator.Send(new DownloadFileFromUrlCommand
            {
                Uri = new Uri("https://rekturacjazadanie.blob.core.windows.net/zadanie/Products.csv"),
                FileName = "Products.csv"
            });

            if (!result.IsSuccess)
                return Result<bool>.Error(result.Errors);

            // process file
            // get list of objects
            var productsQuery = await _mediator.Send(new GetProductsFromFileQuery { FileName = "Products.csv" });

            if (!productsQuery.IsSuccess)
                return Result<bool>.Error(productsQuery.Errors);

            // filter without "kable" and only "24h" (can't do it faster, so this comparison is enough)
            var filteredProducts = productsQuery.Value.Where(x => !x.Category.ToLower().Contains("kable") && x.Shipping == "24h");

            // map to model
            var products = filteredProducts.Select(x => _mapper.Map<Domain.Model.Product.Product>(x)).ToList();

            // add to database
            await _context.Products.AddRangeAsync(products);



            // download and save Inventory.csv file
            result = await _mediator.Send(new DownloadFileFromUrlCommand
            {
                Uri = new Uri("https://rekturacjazadanie.blob.core.windows.net/zadanie/Inventory.csv"),
                FileName = "Inventory.csv"
            });

            if (!result.IsSuccess)
                return Result<bool>.Error(result.Errors);

            // process file
            // get list of objects
            var inventoriesQuery = await _mediator.Send(new GetInventoriesFromFileQuery { FileName = "Inventory.csv" });

            if (!inventoriesQuery.IsSuccess)
                return Result<bool>.Error(inventoriesQuery.Errors);

            // filter only "24h"
            var filteredInventory = inventoriesQuery.Value.Where(x => x.Shipping == "24h");

            // map to model
            var inventory = filteredInventory.Select(x => _mapper.Map<Domain.Model.Inventory.Inventory>(x)).ToList();

            // add to database
            await _context.Inventories.AddRangeAsync(inventory);




            // download and save Prices.csv file
            result = await _mediator.Send(new DownloadFileFromUrlCommand
            {
                Uri = new Uri("https://rekturacjazadanie.blob.core.windows.net/zadanie/Prices.csv"),
                FileName = "Prices.csv"
            });

            if (!result.IsSuccess)
                return Result<bool>.Error(result.Errors);

            // process file
            // get list of objects
            var pricesQuery = await _mediator.Send(new GetPricesFromFileQuery { FileName = "Prices.csv" });

            if (!pricesQuery.IsSuccess)
                return Result<bool>.Error(pricesQuery.Errors);

            // map to model
            var prices = pricesQuery.Value.Select(x => _mapper.Map<Domain.Model.Price.Price>(x)).ToList();

            // add to database
            await _context.Prices.AddRangeAsync(prices);




            // save data
            await _context.SaveBulkDataAsync();

            return Result<bool>.Success(true);
        }

    }
}
