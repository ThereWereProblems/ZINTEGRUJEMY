using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Domain.DTO;
using ZINTEGRUJEMY.Domain.Model.Inventory;

namespace ZINTEGRUJEMY.Application.AutoMapper
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<InventoryDTO, Inventory>();
        }
    }
}
