using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2_hw
{
    public class VandF
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public decimal Calories { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\tName: {Name}\tType: {Type}\tColor: {Color}\tCalories: {Calories}";
        }
    }
}
