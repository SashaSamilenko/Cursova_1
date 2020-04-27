using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    public class Trips : ITrips
    {
        public double kilometrs { get; set; }
        public double waitTime { get; set; }
        public double priceForOneKilometr { get; set; }
        public double waitPrice{ get; set; }
        public string namePassenger { get; set; }
        public string sernamePassenger { get; set; }
        public int key_of_passeger { get; set; }
        public Passeger peo;
        public Discount disc;
        public Trips(Passeger passeger,int key_of_Passeger, double kilometrs, double priceForOneKilometr,double waitTime,double waitPrice)
        {
            if(kilometrs<=0)
            {
                throw new ArgumentNullException("Hours must be more than zero!!!");
            }
            if(priceForOneKilometr<=0)
            {
                throw new ArgumentException("Price for one kilometr must be more than zero!");
            }
            if(waitTime<0)
            {
                throw new ArgumentNullException("wait TIME should be more or equal zero");
            }
            if(waitTime>0 && waitPrice<=0)
            {
                throw new ArithmeticException("Waitng price must be more than zero, when waiting time > 0");
            }
            this.kilometrs = kilometrs;
            this.waitTime = waitTime;
            this.priceForOneKilometr = priceForOneKilometr;
            this.waitPrice = waitPrice;
            this.waitTime = waitTime;
            this.key_of_passeger = key_of_Passeger;
            passeger.countTrips += 1;
            peo = passeger;
            namePassenger = peo.name;
            sernamePassenger = peo.sername;
            disc = new Discount(peo.countTrips);
        }
        public double ToPay()
        {
            return (disc.ToPay(kilometrs, priceForOneKilometr) + waitTime * waitPrice);
        }
        public string Name()
        {
            return namePassenger;
        }
        public string SerName()
        {
            return sernamePassenger;
        }
    }
}
