using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiParks
{
    public delegate void DelegOutPut(List<Trips> NTrip);
    public class Trips : TaxiPark
    {
        public static event DelegOutPut OutPutEvent;
        public static event DelegAdd EventAdd;
        public static event DelegDel EventDel;
        public double kilometrs { get; set; }
        public double waitTime { get; set; }
        public double priceForOneKilometr { get; set; }
        public double waitPrice{ get; set; }
        public string namePassenger { private get; set; }
        public string sernamePassenger { private get; set; }
        public int key_of_passeger { get; set; }
        public Passeger peo;
        public Discount disc;
        public Trips(DelegOutPut OutPutEvent,DelegAdd addEvent,DelegDel deleteEvent)
        {
            if (OutPutEvent!= null)
            {
                Trips.OutPutEvent += OutPutEvent;
            }
            EventAdd = (addEvent != null) ? addEvent : null;
            EventDel = (deleteEvent != null) ? deleteEvent : null;
        }
        public Trips() { }
        public Trips(Passeger passeger,int key_of_Passeger, double kilometrs, double priceForOneKilometr,double waitTime,double waitPrice, DelegOutPut OutPutEvent, DelegAdd addEvent, DelegDel deleteEvent)
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
            namePassenger = peo.Name();
            sernamePassenger = peo.SerName();
            disc = new Discount(peo.countTrips);
            if(OutPutEvent!=null)
            {
                Trips.OutPutEvent += OutPutEvent;
            }
            EventAdd += (addEvent != null) ? addEvent : null;
            EventDel += (deleteEvent != null) ? deleteEvent : null;
        }
        public override double ToPay()
        {
            return (disc.ToPay(kilometrs, priceForOneKilometr) + waitTime * waitPrice);
        }
        public override string Name()
        {
            return namePassenger;
        }
        public override string SerName()
        {
            return sernamePassenger;
        }
        static public void Delete(string name,string sername,int key,List<Trips> trips)
        {
            bool flag = false;
            foreach (var trip in trips)
            {
                if (trip.Name() == name && trip.SerName() == sername && trip.key_of_passeger == key)
                {
                    flag = true;
                    trips.Remove(trip);
                    break;
                }
            }
            if (flag == false)
            {
                throw new ArgumentException("Did not find this person!");
            }
            Trips.EventDel?.Invoke();
        }
        static public void Add(List<Passeger> passegers, List<Trips> NTrip, string name,string sername,int key,double Long, double PriceForOneKilometr,double waiting_time,double waiting_price, DelegOutPut OutPutEvent, DelegAdd addEvent, DelegDel deleteEvent)
        {
            bool flag = false;
            foreach (var val in passegers)
            {
                if (val.Name() == name && val.SerName() == sername && val.key == key)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                throw new ArgumentException("Did not find this person in list of Passegers. We recomendet to you add this person in list of passegers");
            }
            flag = false;
            foreach (var val in NTrip)
            {
                if (val.key_of_passeger == key)
                {
                    throw new ArgumentException("This person yet to drive ");
                }
            }
            flag = false;
            foreach (var Value in passegers)
            {
                if (Value.Name() == name && Value.SerName() == sername && Value.key == key)
                {
                    NTrip.Add(new Trips(Value, key, Long, PriceForOneKilometr, waiting_time, waiting_price,Trips.OutPutEvent, addEvent, deleteEvent));
                    if(OutPutEvent!=null)
                    {
                        Trips.OutPutEvent = OutPutEvent;
                        Trips.OutPutEvent?.Invoke(NTrip);
                    }
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                throw new ArgumentException("Warning: This passeger did not find. You can to try this: add new passeger.");
            }
            Trips.EventAdd?.Invoke();
        }
    }
}
