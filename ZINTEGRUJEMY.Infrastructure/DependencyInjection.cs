using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Application.Common.Abstractions;
using ZINTEGRUJEMY.Infrastructure.Factories;
using ZINTEGRUJEMY.Infrastructure.Persistance;
using ZINTEGRUJEMY.Infrastructure.Services.SourceFile.Handlers;

namespace ZINTEGRUJEMY.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // register factories
            services.AddTransient(typeof(ISorceFileHandlerFactory<>), typeof(SourceFileHandlerFactory<>));

            // register handlers
            services.AddTransient(typeof(CsvFileHandler<>), typeof(CsvFileHandler<>));

            // add dbContext
            services.AddScoped(typeof(IApplicationDbContext), typeof(ApplicationDbContext));
            services.AddDbContextFactory<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbCennection"));
            });

            return services;
        }
    }
}
