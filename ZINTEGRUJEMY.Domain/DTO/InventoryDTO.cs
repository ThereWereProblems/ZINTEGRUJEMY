using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZINTEGRUJEMY.Domain.DTO
{
    public class InventoryDTO
    {
        public InventoryDTO()
        {

        }

        public InventoryDTO(params string[] args)
        {
            try
            {
                var values = args[0].Split(',');

                var rowLenght = values.Length;
                if (rowLenght != 8)
                {
                    IsSuccessfullCreated = false;
                    return;
                }

                ProductId = int.Parse(values[0]);
                SKU = values[1];
                Unit = values[2];
                try
                {
                    Qty = (int)decimal.Parse(values[3], new NumberFormatInfo() { NumberDecimalSeparator = "." });
                }
                catch (Exception)
                {
                    ShippingCost = Qty = (int)decimal.Parse(values[3], new NumberFormatInfo() { NumberDecimalSeparator = "," }); ;
                }
                Manufacturer = values[4];
                Shipping = values[6];
                if (!string.IsNullOrEmpty(values[7]))
                {
                    try
                    {
                        ShippingCost = Decimal.Parse(values[7], new NumberFormatInfo() { NumberDecimalSeparator = "." });
                    }
                    catch (Exception)
                    {
                        ShippingCost = Decimal.Parse(values[7], new NumberFormatInfo() { NumberDecimalSeparator = "," }); ;
                    }
                }

                IsSuccessfullCreated = true;
            }
            catch (Exception ex)
            {
                IsSuccessfullCreated = false;
            }
        }

        public int ProductId { get; set; }
        public string SKU { get; set; }
        public string Unit { get; set; }
        public int Qty { get; set; }
        public string Manufacturer { get; set; }
        public string Shipping { get; set; }
        public decimal ShippingCost { get; set; }

        /// <summary>
        /// If assignment values was successfull
        /// </summary>
        public bool IsSuccessfullCreated { get; set; }

        private string TrimQuote(string value)
        {
            return value.Substring(1, value.Length - 2);
        }
    }
}
