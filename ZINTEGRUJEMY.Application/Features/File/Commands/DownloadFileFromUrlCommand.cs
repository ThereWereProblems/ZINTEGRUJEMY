using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Application.Result;

namespace ZINTEGRUJEMY.Application.Features.File.Commands
{
    public class DownloadFileFromUrlCommand : IRequest<Result<bool>>
    {
        public Uri Uri { get; set; }
        public string FileName { get; set; }
    }

    public class DownloadFileFromUrlCommandValidator : AbstractValidator<DownloadFileFromUrlCommand>
    {
        public DownloadFileFromUrlCommandValidator()
        {
            RuleFor(v => v.Uri)
                .NotNull().NotEmpty().WithMessage("Url jest wymagany!");

            RuleFor(v => v.FileName)
                .NotNull().NotEmpty().WithMessage("Nazwa pliku jest wymagana!");
        }
    }

    public class DownloadFileFromUrlCommandHandler : IRequestHandler<DownloadFileFromUrlCommand, Result<bool>>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DownloadFileFromUrlCommandHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Result<bool>> Handle(DownloadFileFromUrlCommand request, CancellationToken cancellationToken)
        {
            // Create wwwroot directory if not exists
            if (!System.IO.Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files")))
                System.IO.Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files"));

            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", request.FileName);

            // download and save file
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(request.Uri, path);
                }
            }
            catch (Exception)
            {
                // TODO - some log
                return Result<bool>.Error($"Błąd podczas pobierania pliku {request.FileName}");
            }

            return Result<bool>.Success(true);
        }
    }
}
