using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> arr, IEnumerable<T> items)
        {
            foreach (var i in items)
            {
                arr.Add(i);
            }
        }
    }
}
