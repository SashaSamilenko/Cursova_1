using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    public class Discount
    {
        public double discount{ get; set; }
        public int countTrips;
        public Discount(int countTrips)
        {
            this.countTrips = countTrips;
        }
        public double ToPay(double hours,double priceOne)
        {
            discount = countTrips % priceOne+9;
            return (priceOne * hours * (1 - discount/89));
        }
    }
}
