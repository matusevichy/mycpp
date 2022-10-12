using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less3_hw.Models
{
    public class Report
    {
        public List<ReportItem> items { get; set; } = new List<ReportItem>();
        public List<TopList> topLists { get; set; } =new List<TopList>();

        public bool Save()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("log.txt", false, Encoding.Default))
                {
                    foreach (var item in items)
                    {
                        writer.WriteLine(item);
                    }
                    writer.WriteLine("Toplist of the forbidden words");
                    var topList = items.SelectMany(w => w.ReplacedWord).GroupBy(w => w.Key).Select(w => new TopList { Name = w.Key, Count = w.Sum(s => s.Value) }).ToList();
                    topLists = topList;
                    foreach (var item in topLists)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AddItem(ReportItem item)
        {
            items.Add(item);
        }
    }
}
