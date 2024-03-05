using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Application.Common.Abstractions;

namespace ZINTEGRUJEMY.Infrastructure.Services.SourceFile.Handlers
{
    public class CsvFileHandler<T> : ISorceFileHandler<T> where T : class, new()
    {
        public async Task<bool> IsSuitable(string fileName)
        {
            var fileExtension = System.IO.Path.GetExtension(fileName);

            if (fileExtension == ".csv")
                return true;
            else
                return false;
        }

        public async Task<List<T>> Handle(string path, bool skipFirstLine = true)
        {
            // read file and convert to list of objects
            var listOfObjects = System.IO.File.ReadAllLines(path).ToList();

            if (listOfObjects.Count > 0 && skipFirstLine)
                listOfObjects.RemoveAt(0);

            var result = listOfObjects.Select(x => (T)Activator.CreateInstance(typeof(T), x)).ToList();

            return result;
        }
    }
}
