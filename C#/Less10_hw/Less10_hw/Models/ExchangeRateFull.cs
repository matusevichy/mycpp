using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less10_hw.Models
{
    public class ExchangeRateFull
    {
        public string BaseCurrency { get; set; }
        public string Currency { get; set; }
        public double SaleRateNB { get; set; }
        public double PurchaseRateNB { get; set; }
        public double? SaleRate { get; set; }
        public double? PurchaseRate { get; set; }
        public override string ToString()
        {
            string str = $"BaseCurrency: {BaseCurrency}, Currency: {Currency}, SaleRateNB: {SaleRateNB}, PurchaseRateNB: {PurchaseRateNB}";
            if (SaleRate.HasValue)
            {
                str += $", SaleRate: {SaleRate}";
            }
            if (PurchaseRate.HasValue)
            {
                str += $", PurchaseRate: {PurchaseRate}";
            }
            return str;
        }
    }
}
