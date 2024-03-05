using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Domain.DTO;
using ZINTEGRUJEMY.Domain.ReadModel;

namespace ZINTEGRUJEMY.Application.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Domain.Model.Product.Product>();
            CreateMap<Domain.Model.Product.Product, ProductSearchResult>();
        }
    }
}
