using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZINTEGRUJEMY.Application.Common.Abstractions
{
    public interface ISorceFileHandler<T> where T : class
    {
        Task<bool> IsSuitable(string fileName);
        Task<List<T>> Handle(string path, bool skipFirstLine = true);
    }
}
