using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZINTEGRUJEMY.Domain.Model.Inventory;

namespace ZINTEGRUJEMY.Domain.Model.Price
{
    public class Price
    {
        /// <summary>
        /// Unique ID, only used by internal warehouse system.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Product SKU, unique value created by warehouse
        /// </summary>
        [Key]
        public string SKU { get; set; }

        /// <summary>
        /// Nett product price
        /// </summary>
        public decimal NettPrice { get; set; }

        /// <summary>
        /// product price after discount
        /// </summary>
        public decimal NettPriceAfterDiscount { get; set; }

        /// <summary>
        /// VAT rate
        /// </summary>
        public decimal VAT { get; set; }

        /// <summary>
        /// Nett product price after discount for product logistic unit
        /// </summary>
        public decimal NettPriceAfterDiscountPerUnit { get; set; }
    }
}
