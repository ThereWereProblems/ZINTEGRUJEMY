using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZINTEGRUJEMY.Domain.Model.Inventory
{
    public class Inventory
    {
        /// <summary>
        /// Unique ID of the product
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product SKU, unique value created by warehouse
        /// </summary>
        [Key]
        public string SKU { get; set; }

        /// <summary>
        /// Type of unit the product is sold as
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Stock quantity
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        /// Product Manufacturer
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Shipping time
        /// </summary>
        public string Shipping { get; set; }

        /// <summary>
        /// Nett cost for shipping product
        /// </summary>
        public decimal ShippingCost { get; set; }
    }
}
