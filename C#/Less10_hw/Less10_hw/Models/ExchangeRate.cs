using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less10_hw.Models
{
    public class ExchangeRate
    {
        [JsonProperty ("ccy")]
        public string CurrencyTo { get; set; }
        [JsonProperty ("base_ccy")]
        public string CurrencyFrom { get; set; }
        public double Buy { get; set; }
        public double Sale { get; set; }
        public override string ToString()
        {
            return $"CurrencyFrom: {CurrencyFrom}, CurrencyTo: {CurrencyTo}, Buy: {Buy}, Sale: {Sale}";
        }
    }
}
