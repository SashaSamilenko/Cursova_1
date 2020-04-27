using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    public class Edit_informations:Information
    {
        public Information info = new Information();
        public void deleteWorker(List<Workers> workers)
        {
            Console.Write("key = ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            bool flag = false;
            foreach (var worker in workers)
            {
                if (worker.key == key && worker.name == name && worker.sername == sername)
                {
                    flag = true;
                    workers.Remove(worker);
                    break;
                }
            }
            if (flag == false)
            {
                throw new ArgumentException("Did not find this person!");
            }
            info.OutPutWorkersInFile(workers);
        }
        public void deleteTrip(List<Trips> trips)
        {
            Console.Write("Key = ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
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
            info.OutPutListOfTripsInTheFile(trips);
        }
        public void deletePasseger(List<Passeger> passegers, List<Trips> trips)
        {
            Console.Write("Key = ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
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
                if (passeger.name == name && passeger.sername == sername && passeger.key == key)
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
                    if (passeger.name == trips[i].Name() && passeger.sername == trips[i].SerName())
                    {
                        trips[i].key_of_passeger = passeger.key;
                    }
                }
            }
            info.OutPutPassegersInFile(passegers);
            info.OutPutListOfTripsInTheFile(trips);
        }
        public void AddNewPasseger(ref List<Passeger> pass)
        {
            Console.Write("New name: ");
            string name = Console.ReadLine();
            Console.Write("New Sername: ");
            string sername = Console.ReadLine();
            int countofList = pass[pass.Count() - 1].key + 1;
            pass.Add(new Passeger(name, sername, 0, countofList));
            info.OutPutPassegersInFile(pass);
        }
        public void AddNewWorker(ref List<Workers> workers)
        {
            Console.Write("New name: ");
            string name = Console.ReadLine();
            Console.Write("New Sername: ");
            string sername = Console.ReadLine();
            Console.Write("salaryInOur: ");
            double salary = Convert.ToDouble(Console.ReadLine());
            if (salary <= 0)
            {
                throw new ArgumentNullException("Salary must be more than zero!!!");
            }
            Console.WriteLine("Date of starting: ");
            DateTime timeOfStarting = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Date of finishing: ");
            DateTime timeOfFinishing = DateTime.Parse(Console.ReadLine());
            int countofList = workers[workers.Count() - 1].key;
            workers.Add(new Workers() { key = countofList + 1, name = name, sername = sername, salaryInOur = salary, timeStart = timeOfStarting, timeFinish = timeOfFinishing });
            info.OutPutWorkersInFile(workers);
        }
        public void AddTrip(ref List<Trips> NTrip, List<Passeger> passegers)
        {
            Console.Write("Key = ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            bool flag = false;
            foreach (var val in passegers)
            {
                if (val.name == name && val.sername == sername && val.key == key)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                throw new ArgumentException("Did not find this person in list of Passegers. We recomendet to you add this person in list of passegers");
            }
            Console.Write("Long:");
            double Long = Convert.ToDouble(Console.ReadLine());
            if (Long <= 0)
            {
                throw new ArgumentNullException("Long must be more than zero!!!");
            }
            Console.Write("Price for one kilimert: ");
            double PriceForOneKilometr = Convert.ToDouble(Console.ReadLine());
            if (PriceForOneKilometr <= 0)
            {
                throw new ArithmeticException("Price for a one kilometrs should be more than 0!");
            }
            Console.Write("Waiting time: ");
            double waiting_time = Convert.ToDouble(Console.ReadLine());
            if (waiting_time < 0)
            {
                throw new ArgumentException("Waiting time must be >= 0");
            }
            Console.Write("Waiting price: ");
            double waiting_price = Convert.ToDouble(Console.ReadLine());
            if (waiting_price < 0)
            {
                throw new ArgumentException("Price for a waiting should be more than zero or is equal with zero!!!");
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
                if (Value.name == name && Value.sername == sername && Value.key == key)
                {
                    NTrip.Add(new Trips(Value, key, Long, PriceForOneKilometr, waiting_time, waiting_price));
                    info.OutPutListOfTripsInTheFile(NTrip);
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                throw new ArgumentException("Warning: This passeger did not find. You can to try this: add new passeger.");
            }
            info.OutPutListOfTripsInTheFile(NTrip);
            info.OutPutPassegersInFile(passegers);
        }
    }
}
