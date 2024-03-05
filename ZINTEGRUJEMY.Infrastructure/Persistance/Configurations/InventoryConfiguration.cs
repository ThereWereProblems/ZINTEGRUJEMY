using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Domain.Model.Inventory;

namespace ZINTEGRUJEMY.Infrastructure.Persistance.Configurations
{
    public partial class InventoryConfiguration : IEntityTypeConfiguration<Domain.Model.Inventory.Inventory>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.Inventory.Inventory> entity)
        {
            entity.ToTable("Inventories");

            entity.HasKey("SKU");

            entity.Property<string>("SKU")
                .HasColumnType("nvarchar(450)");

            entity.Property<string>("Manufacturer")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            entity.Property<int>("ProductId")
                .HasColumnType("int");

            entity.Property<int>("Qty")
                .HasColumnType("int");

            entity.Property<string>("Shipping")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            entity.Property<decimal>("ShippingCost")
                .HasColumnType("decimal(18,2)");

            entity.Property<string>("Unit")
                .IsRequired()
                .HasColumnType("nvarchar(max)");
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Inventory> entity);
    }
}
