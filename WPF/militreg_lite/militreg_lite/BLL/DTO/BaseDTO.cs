using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class BaseDTO:INotifyPropertyChanged
    {
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
