using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Domain.Model.Product;

namespace ZINTEGRUJEMY.Infrastructure.Persistance.Configurations
{
    public partial class ProductConfiguration : IEntityTypeConfiguration<Domain.Model.Product.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.Product.Product> entity)
        {
            entity.ToTable("Products");

            entity.HasKey("SKU");

            entity.Property<string>("SKU")
                .HasColumnType("nvarchar(450)");

            entity.Property<bool>("Available")
                .HasColumnType("bit");

            entity.Property<string>("Category")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            entity.Property<string>("DefaultImage")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            entity.Property<string>("EAN")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            entity.Property<int>("Id")
                .HasColumnType("int");

            entity.Property<bool>("IsVendor")
                .HasColumnType("bit");

            entity.Property<bool>("IsWire")
                .HasColumnType("bit");

            entity.Property<string>("Name")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            entity.Property<string>("ProducerName")
                .IsRequired()
                .HasColumnType("nvarchar(max)");
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Product> entity);
    }
}
