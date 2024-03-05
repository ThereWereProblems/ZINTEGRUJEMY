using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Domain.Model.Inventory;
using ZINTEGRUJEMY.Domain.Model.Price;
using ZINTEGRUJEMY.Domain.Model.Product;

namespace ZINTEGRUJEMY.Application.Common.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Inventory> Inventories { get; set; }
        DbSet<Price> Prices { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default);
        Task SaveBulkDataAsync();
    }
}
