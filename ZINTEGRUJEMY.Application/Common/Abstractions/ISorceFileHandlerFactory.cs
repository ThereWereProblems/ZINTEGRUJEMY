using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZINTEGRUJEMY.Application.Common.Abstractions
{
    public interface ISorceFileHandlerFactory<T> where T : class, new()
    {
        Task<ISorceFileHandler<T>> GetInstance(string fileName);
    }
}
