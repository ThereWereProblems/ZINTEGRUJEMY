using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZINTEGRUJEMY.Domain.Model.Product
{
    public class Product
    {
        /// <summary>
        /// Unique ID of the product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product SKU, unique value created by warehouse
        /// </summary>
        [Key]
        public string SKU { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product numbe
        /// </summary>
        public string EAN { get; set; }

        /// <summary>
        /// Supplier name
        /// </summary>
        public string ProducerName { get; set; }

        /// <summary>
        /// Product Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Indicates whether the product is a wire (if value is 1)
        /// </summary>
        public bool IsWire { get; set; }

        /// <summary>
        /// Indicates whether the product is available for order (if value is 1)
        /// </summary>
        public bool Available { get; set; }

        /// <summary>
        /// Indicates whether the product is shipped by supplier or warehouse. If value is 0, it’s shipped by warehouse, if 1, it’s shipped by supplier.
        /// </summary>
        public bool IsVendor { get; set; }

        /// <summary>
        ///  URL address to product’s image
        /// </summary>
        public string DefaultImage { get; set; }
    }
}
