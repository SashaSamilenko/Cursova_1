using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    public class Passeger
    {
        public string name { get; set; }
        public string sername { get; set; }
        public int countTrips=0;
        public int key { get; set; }
        public Passeger(string name,string sername,int countTrips,int key)
        {
            if(name.Length==0 || name==null||sername.Length==0||sername==null)
            {
                throw new ArgumentNullException("String of name has a lenght with is equal to null!");
            }
            if(countTrips<0)
            {
                throw new ArgumentException("count of trips this passeger must be more or equal zero");
            }
            this.name = name;
            this.sername = sername;
            this.countTrips = countTrips;
            this.key = key;
        }
    }
}
