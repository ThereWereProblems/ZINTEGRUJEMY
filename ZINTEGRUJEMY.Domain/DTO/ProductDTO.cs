using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZINTEGRUJEMY.Domain.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {

        }

        public ProductDTO(params string[] args)
        {
            try
            {
                var values = args[0].Split(';');

                var rowLenght = values.Length;
                if (rowLenght != 19) 
                {
                    IsSuccessfullCreated = false;
                    return;
                }

                Id = int.Parse(TrimQuote(values[0]));
                SKU = TrimQuote(values[1]);
                Name = TrimQuote(values[2]);
                EAN = TrimQuote(values[4]);
                ProducerName = TrimQuote(values[6]);
                Category = TrimQuote(values[7]);
                IsWire = int.Parse(TrimQuote(values[8])) != 0;
                Shipping = TrimQuote(values[9]);
                Available = int.Parse(TrimQuote(values[11])) != 0;
                IsVendor = int.Parse(TrimQuote(values[16])) != 0;
                DefaultImage = TrimQuote(values[18]);

                IsSuccessfullCreated = true;
            }
            catch (Exception ex)
            {
                IsSuccessfullCreated = false;
            }
        }


        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string EAN { get; set; }
        public string ProducerName { get; set; }
        public string Category { get; set; }
        public bool IsWire { get; set; }
        public string Shipping {  get; set; }
        public bool Available { get; set; }
        public bool IsVendor { get; set; }
        public string DefaultImage { get; set; }

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
