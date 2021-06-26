using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less10_hw.Models
{
    class Department
    {
        public String Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Index { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Country: {Country}\n State: {State}\n City: {City}\n Index: {Index}\n Address: {Address}\n Phone: {Phone}\n Email: {Email}\n Name: {Name}";
        }
    }
}
