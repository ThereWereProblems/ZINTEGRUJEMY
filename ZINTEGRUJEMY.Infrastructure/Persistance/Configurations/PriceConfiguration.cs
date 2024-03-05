using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Domain.Model.Price;

namespace ZINTEGRUJEMY.Infrastructure.Persistance.Configurations
{
    public partial class PriceConfiguration : IEntityTypeConfiguration<Domain.Model.Price.Price>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.Price.Price> entity) 
        {
            entity.ToTable("Prices");

            entity.HasKey("SKU");

            entity.Property<string>("SKU")
                .HasColumnType("nvarchar(450)");

            entity.Property<string>("Id")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            entity.Property<decimal>("NettPrice")
                .HasColumnType("decimal(18,2)");

            entity.Property<decimal>("NettPriceAfterDiscount")
                .HasColumnType("decimal(18,2)");

            entity.Property<decimal>("NettPriceAfterDiscountPerUnit")
                .HasColumnType("decimal(18,2)");

            entity.Property<decimal>("VAT")
                .HasColumnType("decimal(18,2)");
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Price> entity);
    }
}
