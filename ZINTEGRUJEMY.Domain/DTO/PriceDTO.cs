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
    public class PriceDTO
    {
        public PriceDTO()
        {
            
        }

        public PriceDTO(params string[] args)
        {
            try
            {
                var values = TrimQuote(args[0]).Split("\",\"");

                var rowLenght = values.Length;
                if (rowLenght != 6)
                {
                    IsSuccessfullCreated = false;
                    return;
                }

                Id = values[0];
                SKU = values[1];
                if (!string.IsNullOrEmpty(values[2]))
                {
                    try
                    {
                        NettPrice = Decimal.Parse(values[2], new NumberFormatInfo() { NumberDecimalSeparator = "," });
                    }
                    catch (Exception)
                    {
                        NettPrice = Decimal.Parse(values[2], new NumberFormatInfo() { NumberDecimalSeparator = "." });
                    }
                }
                if (!string.IsNullOrEmpty(values[3]))
                {
                    try
                    {
                        NettPriceAfterDiscount = Decimal.Parse(values[3], new NumberFormatInfo() { NumberDecimalSeparator = "," });
                    }
                    catch (Exception)
                    {
                        NettPriceAfterDiscount = Decimal.Parse(values[3], new NumberFormatInfo() { NumberDecimalSeparator = "." }); ;
                    }
                }
                if (!string.IsNullOrEmpty(values[4]))
                {
                    try
                    {
                        VAT = Decimal.Parse(values[4], new NumberFormatInfo() { NumberDecimalSeparator = "," });
                    }
                    catch (Exception)
                    {
                        VAT = Decimal.Parse(values[4], new NumberFormatInfo() { NumberDecimalSeparator = "." });

                    }
                }
                if (!string.IsNullOrEmpty(values[5]))
                {
                    try
                    {
                        NettPriceAfterDiscountPerUnit = Decimal.Parse(values[5], new NumberFormatInfo() { NumberDecimalSeparator = "," });
                    }
                    catch (Exception)
                    {
                        NettPriceAfterDiscountPerUnit = Decimal.Parse(values[5], new NumberFormatInfo() { NumberDecimalSeparator = "." }); ;
                    }
                }


                IsSuccessfullCreated = true;
            }
            catch (Exception ex)
            {
                IsSuccessfullCreated = false;
            }
        }


        public string Id { get; set; }
        public string SKU { get; set; }
        public decimal NettPrice { get; set; }
        public decimal NettPriceAfterDiscount { get; set; }
        public decimal VAT { get; set; }
        public decimal NettPriceAfterDiscountPerUnit { get; set; }

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
