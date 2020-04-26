using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    public class Workers : ITrips
    {
        public string name { get; set; }
        public string sername { get; set; }
        public double salaryInOur { get; set; }
        public double timeInWeek { get; set;}
        public DateTime timeStart{ get; set; }
        public DateTime timeFinish { get; set; }
        public Workers() { }
        public string Name()
        {
            return name;
        }
        public string SerName()
        {
            return sername;
        }
        public double ToPay()
        {
            return 5* salaryInOur*((Convert.ToDouble(timeFinish.Hour) + Convert.ToDouble(timeFinish.Minute) / 60) - (Convert.ToDouble(timeStart.Hour) + Convert.ToDouble(timeStart.Minute) / 60));
        }
    }
}
