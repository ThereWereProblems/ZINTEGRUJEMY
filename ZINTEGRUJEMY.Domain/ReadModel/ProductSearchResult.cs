﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZINTEGRUJEMY.Domain.ReadModel
{
    public class ProductSearchResult
    {
        public string Name { get; set; }
        public string EAN { get; set; }
        public string ProducerName { get; set; }
        public string Category { get; set; }
        public string DefaultImage { get; set; }
        public int Qty { get; set; }
        public string Unit { get; set; }
        public decimal NettPrice { get; set; }
        public decimal ShippingCost { get; set; }

    }
}
