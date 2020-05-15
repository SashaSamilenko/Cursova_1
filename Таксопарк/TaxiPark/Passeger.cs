using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaxiParks
{
    public delegate void DelegAdd();
    public delegate void DelegDel();
    public class Passeger: TaxiPark
    {
        public static event DelegAdd EventAdd;
        public static event DelegDel EventDel;
        public int countTrips=0;
        public int key { get; set; }
        public Passeger(){}
        public Passeger(string name,string sername,int countTrips,int key, DelegAdd addEvent, DelegDel deleteEvent)
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
            EventAdd = (addEvent != null) ? addEvent : null;
            EventDel = (deleteEvent != null) ? deleteEvent : null;
        }
        static public void Delete(List<Trips> trips,List<Passeger> passegers,string name,string sername,int key)
        {
            bool flag = false;
            foreach (var trip in trips)
            {
                if (trip.key_of_passeger == key && trip.Name() == name && trip.SerName() == sername)
                {
                    trips.Remove(trip);
                    break;
                }
            }
            foreach (var passeger in passegers)
            {
                if (passeger.Name() == name && passeger.SerName() == sername && passeger.key == key)
                {
                    flag = true;
                    passegers.Remove(passeger);
                    break;
                }
            }

            if (flag == false)
            {
                throw new ArgumentException("Did not find this person!");
            }
            for (int i = 0; i < passegers.Count(); i++)
            {
                passegers[0].key = i;
            }
            foreach (var passeger in passegers)
            {
                for (int i = 0; i < trips.Count(); i++)
                {
                    if (passeger.Name() == trips[i].Name() && passeger.SerName() == trips[i].SerName())
                    {
                        trips[i].key_of_passeger = passeger.key;
                    }
                }
            }
            Passeger.EventDel?.Invoke();
        }
        public static void Add(List<Passeger> pass, string name,string sername, DelegAdd addEvent, DelegDel deleteEvent)
        {
            int countofList = pass[pass.Count() - 1].key + 1;
            pass.Add(new Passeger(name, sername, 0, countofList, addEvent, deleteEvent));
            Passeger.EventAdd?.Invoke();
        }
    }
}
