using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiParks
{
    public abstract class TaxiPark:ITrips
    {
        public string name { private get; set; }
        public string sername { private get; set; }
        public virtual string Name()
        {
            return name;
        }
        public virtual string SerName()
        {
            return sername;
        }
        public virtual double ToPay()
        {
            return 0;
        }
    }
}