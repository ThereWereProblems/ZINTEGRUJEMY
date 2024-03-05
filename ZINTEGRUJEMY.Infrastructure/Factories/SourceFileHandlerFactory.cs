using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Application.Common.Abstractions;
using ZINTEGRUJEMY.Infrastructure.Services.SourceFile.Handlers;

namespace ZINTEGRUJEMY.Infrastructure.Factories
{
    public class SourceFileHandlerFactory<T> : ISorceFileHandlerFactory<T> where T : class, new()
    {
        private readonly List<ISorceFileHandler<T>> _handlers = new List<Application.Common.Abstractions.ISorceFileHandler<T>>();

        public SourceFileHandlerFactory(CsvFileHandler<T> csvFileHandler)
        {
            _handlers.AddRange(new List<ISorceFileHandler<T>>
            {
                // factory with place for other extenstions
                csvFileHandler
            });
        }

        public async Task<ISorceFileHandler<T>> GetInstance(string fileName)
        {
            // find right factory
            foreach (var handler in _handlers)
            {
                if (await handler.IsSuitable(fileName))
                    return handler;
            }
            return null;
        }
    }
}
