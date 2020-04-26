using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    public class Information
    {
        public Information()
        {

        }
        public void WorkersInformationOfList(List<Workers> kind)
        {
            Console.WriteLine("\t\tList of workers:");
            Console.WriteLine("Name".PadRight(15) + "Sername".PadRight(15) + "All salary in the week".PadRight(25)+"TimeToStart".PadRight(15)+"TimeToFinish".PadRight(15));
            foreach (var Obj in kind)
            {
                Console.WriteLine(Obj.Name().PadRight(15) + Obj.SerName().PadRight(15) + Math.Round(Obj.ToPay(), 2).ToString() + "$".PadRight(25 - Math.Round(Obj.ToPay(), 2).ToString().Length) + Obj.timeStart.ToShortTimeString().PadRight(15) + Obj.timeFinish.ToShortTimeString().PadRight(15));
            }
        }
        public void PassegersInformation(List<Passeger> passeger)
        {
            Console.WriteLine($"\t\tList of passegers:");
            Console.WriteLine("Name".PadRight(15) + "Sername".PadRight(15) + "Count of trips".PadRight(15));
            foreach (var Obj in passeger)
            {
                Console.WriteLine(Obj.name.PadRight(15) + Obj.sername.PadRight(15) + Obj.countTrips.ToString().PadRight(15));
            }
        }
        public void TripsInformation(List<Trips> listOfNowTrips)
        {
            Console.WriteLine("\t\tList of trips");
            Console.WriteLine($"Name".PadRight(15)+"Sername".PadRight(15)+"Price".PadRight(15)+"Long".PadRight(15)+"TimeInWaiting".PadRight(15));
            foreach (var Obj in listOfNowTrips)
            {
                Console.WriteLine(Obj.Name().PadRight(15) + Obj.SerName().PadRight(15) + Math.Round(Obj.ToPay(), 2).ToString()+"$".PadRight(15- Math.Round(Obj.ToPay(), 2).ToString().Length) +Obj.kilometrs.ToString().PadRight(15) + Obj.waitTime.ToString()+"(hour.)".PadRight(15- Obj.waitTime.ToString().Length));
            }
        }
    }
}
