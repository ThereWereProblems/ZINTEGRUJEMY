using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Domain.DTO;

namespace ZINTEGRUJEMY.Application.AutoMapper
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<PriceDTO, Domain.Model.Price.Price>();
        }
    }
}
