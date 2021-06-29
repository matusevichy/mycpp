using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Less11_hw.Models
{
    public class CustomDataRangeAttribute : RangeAttribute
    {
        public CustomDataRangeAttribute() : base(typeof(DateTime), DateTime.Now.AddYears(-120).ToString(), DateTime.Now.ToString())
        {
        }
    }
}
