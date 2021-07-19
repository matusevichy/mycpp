using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw
{
    public class Shipper
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\tCompany Name: {CompanyName}\t Phone: {Phone}";
        }
    }
}
