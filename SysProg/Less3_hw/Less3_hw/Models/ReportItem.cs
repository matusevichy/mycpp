using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less3_hw.Models
{
    public class ReportItem
    {
        public string  Name  { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public int ReplaceCount { get; set; }
        public Dictionary<string,int> ReplacedWord { get; set; }

        public override string ToString()
        {
            return $"{Name}|{Path}|{Size}|{ReplaceCount}|{string.Join(';',ReplacedWord.Select(d => string.Join('=',d.Key,d.Value)))}";
        }
    }
}
