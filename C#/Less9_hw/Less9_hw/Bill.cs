using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Less9_hw
{
    [Serializable]
    public class Bill:ISerializable
    {

        public double PayOfDay { get; set; }
        public int DayCount { get; set; }
        public double FineOfDay { get; set; }
        public int DelayDayCount { get; set; }
        public double SumForPayWithoutFine => PayOfDay * DayCount;
        public double SumFine => FineOfDay * DelayDayCount;
        public double FullSum => SumForPayWithoutFine + SumFine;
        public static bool SerializeAll { get; set; }
        public Bill()
        {
            Bill.SerializeAll = true;
        }
        public Bill(SerializationInfo info, StreamingContext context)
        {
            double dt;
            int it;
            double.TryParse(info.GetString("PayOfDay"), out dt);
            PayOfDay = dt;
            int.TryParse(info.GetString("DayCount"), out it);
            DayCount = it;
            double.TryParse(info.GetString("FineOfDay"), out dt);
            FineOfDay = dt;
            int.TryParse(info.GetString("DelayDayCount"), out it);
            DelayDayCount = it;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("PayOfDay", PayOfDay);
            info.AddValue("DayCount", DayCount);
            info.AddValue("FineOfDay", FineOfDay);
            info.AddValue("DelayDayCount", DelayDayCount);
            if (SerializeAll)
            {
                info.AddValue("SumForPayWithoutFine", SumForPayWithoutFine);
                info.AddValue("SumFine", SumFine);
                info.AddValue("FullSum", FullSum);
            }
        }
        public override string ToString()
        {
            return $"PayOfDay = {PayOfDay}, DayCount = {DayCount}, FineOfDay = {FineOfDay}, DelayDayCount = {DelayDayCount}, SumForPayWithoutFine = {SumForPayWithoutFine}, SumFine = {SumFine}, FullSum = {FullSum}";
        }
    }
}
