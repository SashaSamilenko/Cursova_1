using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaxiParks
{
    public class Information
    {
        public Information()
        {

        }
        /*public void WorkersInformationOfList(List<Workers> kind)
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
            Console.WriteLine("Key".PadRight(15)+"Name".PadRight(15) + "Sername".PadRight(15) + "Count of trips".PadRight(15));
            foreach (var Obj in passeger)
            {
                Console.WriteLine(Obj.key.ToString().PadRight(15)+Obj.Name().PadRight(15) + Obj.SerName().PadRight(15) + Obj.countTrips.ToString().PadRight(15));
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
        public void FindPasseger(List<Passeger> passeger)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            bool flag = false;
            foreach (var value in passeger)
            {
                if (value.Name() == name && value.SerName() == sername)
                {
                    if (flag == false)
                    {
                        Console.WriteLine("Key".PadRight(15) + "Name".PadRight(15) + "Sername".PadRight(15) + "Count of trips".PadRight(15));
                    }
                    flag = true;
                    Console.WriteLine(value.key.ToString().PadRight(15) + value.Name().PadRight(15) + value.SerName().PadRight(15) + value.countTrips.ToString().PadRight(15));
                }
            }
            if (flag == false)
            {
                Console.WriteLine("This person did not find in list with passegers!!!");
            }
        }
        public void FindTrips(List<Trips> trips)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            bool flag = false;
            foreach (var value in trips)
            {
                if (value.Name() == name && value.SerName() == sername)
                {
                    if (flag == false)
                    {
                        Console.WriteLine("Key".PadRight(15) + "Name".PadRight(15) + "Sername".PadRight(15) + "Long".PadRight(15) + "Full- Price".PadRight(15));
                    }
                    flag = true;
                    Console.WriteLine(value.key_of_passeger.ToString().PadRight(15) + value.Name().PadRight(15) + value.SerName().PadRight(15) + value.kilometrs.ToString().PadRight(15) + Math.Round(value.ToPay(), 2).ToString() + "$".PadRight(15 - Math.Round(value.ToPay(), 2).ToString().Length));
                }
            }
            if (flag == false)
            {
                Console.WriteLine("This person did not find in list with trips!!!");
            }
        }
        public void FindWorker(List<Workers> workers)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            bool flag = false;
            foreach (var value in workers)
            {
                if (value.Name() == name && value.SerName() == sername)
                {
                    if (flag == false)
                    {
                        Console.WriteLine("Key".PadRight(15) + "Name".PadRight(15) + "Sername".PadRight(15) + "Salary".PadRight(15));
                    }
                    flag = true;
                    Console.WriteLine(value.key.ToString().PadRight(15) + value.Name().PadRight(15) + value.SerName().PadRight(15) + value.ToPay().ToString().PadRight(15));
                }
            }
            if (flag == false)
            {
                Console.WriteLine("This persone did not find in list with workers!!!");
            }
        }
        public void InputWorkers(ref List<Workers> listWorkers)
        {
            string pathToWorkers = @"ListOfWorkers.txt";
            FileInfo fileInf = new FileInfo(pathToWorkers);
            StreamReader inWork = new StreamReader(pathToWorkers);
            string wors = inWork.ReadToEnd();
            int files_count = 0;
            int lenght = Convert.ToInt32(fileInf.Length);
            while (files_count < lenght)
            {
                string name = "\0", sername = "\0", dateofStart = "\0", dateofFinish = "\0";
                double salary = 0;
                string s = "";
                char c = ' ';
                int key = 0;
                c = wors[files_count];
                files_count += 1;
                s += c;
                int k_space = 1;
                while (c != '\n' && files_count < lenght)
                {
                    c = wors[files_count];
                    files_count += 1;
                    if (c == ' ' || files_count == lenght || c == '\n')
                    {
                        if (files_count == lenght)
                        {
                            s += c;
                        }
                        switch (k_space)
                        {
                            case 1: key = Convert.ToInt32(s); break;
                            case 2: name = s; break;
                            case 3: sername = s; break;
                            case 4: salary = Convert.ToDouble(s); break;
                            case 5: dateofStart = s; break;
                            case 6: dateofFinish = s; break;
                        }
                        k_space += 1;
                        s = "";
                    }
                    else
                    {
                        s += c;
                    }
                }
                listWorkers.Add(new Workers() { key = key, name = name, sername = sername, salaryInOur = salary, timeStart = DateTime.Parse(dateofStart), timeFinish = DateTime.Parse(dateofFinish) });
            }
            inWork.Close();
        }
        public void InputPasseger(ref List<Passeger> listOfPassegers)
        {
            string pathToPassegers = @"ListOfPassegers.txt";
            FileInfo fileInf = new FileInfo(pathToPassegers);
            StreamReader inWork = new StreamReader(pathToPassegers);
            string wors = inWork.ReadToEnd();
            int files_count = 0;
            int lenght = Convert.ToInt32(fileInf.Length);
            while (files_count < lenght)
            {
                string name = "\0", sername = "\0";
                int count_of_trips = 0;
                string s = "";
                char c = ' ';
                int key = 0;
                c = wors[files_count];
                files_count += 1;
                s += c;
                int k_space = 1;
                while (c != '\n' && files_count < lenght)
                {
                    c = wors[files_count];
                    files_count += 1;
                    if (c == ' ' || files_count == lenght || c == '\n')
                    {
                        if (files_count == lenght)
                        {
                            s += c;
                        }
                        switch (k_space)
                        {
                            case 1: key = Convert.ToInt32(s); break;
                            case 2: name = s; break;
                            case 3: sername = s; break;
                            case 4: count_of_trips = Convert.ToInt32(s); break;
                        }
                        k_space += 1;
                        s = "";
                    }
                    else
                    {
                        s += c;
                    }
                }
                listOfPassegers.Add(new Passeger(name, sername, count_of_trips, key));
            }
            inWork.Close();
        }
       public void InputNowListOfTrips(ref List<Trips> ArrgOfTrips, List<Passeger> passegers)
        {
            string pathNowTrips = @"ListOfTrips.txt";
            FileInfo fileInf = new FileInfo(pathNowTrips);
            StreamReader inTrip = new StreamReader(pathNowTrips);
            string trees = inTrip.ReadToEnd();
            int files_count = 0;
            int lenght = Convert.ToInt32(fileInf.Length);
            while (files_count < lenght)
            {
                int key = 0;
                double Long = 0;
                double TripNowPrice = 0;
                double waiting_time = 0;
                double waiting_price = 0;
                string s = "";
                char c = ' ';
                c = trees[files_count];
                files_count += 1;
                s += c;
                int k_space = 1;
                while (c != '\n' && files_count < lenght)
                {
                    c = trees[files_count];
                    files_count += 1;
                    if (c == ' ' || files_count == lenght || c == '\n')
                    {
                        if (files_count == lenght)
                        {
                            s += c;
                        }
                        switch (k_space)
                        {
                            case 1: key = Convert.ToInt32(s); break;
                            case 2: Long = Convert.ToDouble(s); break;
                            case 3: TripNowPrice = Convert.ToDouble(s); break;
                            case 4: waiting_time = Convert.ToDouble(s); break;
                            case 5: waiting_price = Convert.ToDouble(s); break;
                        }
                        k_space += 1;
                        s = "";
                    }
                    else
                    {
                        s += c;
                    }
                }
                for (int i = 0; i < passegers.Count(); i++)
                {
                    if (passegers[i].key == key)
                    {
                        ArrgOfTrips.Add(new Trips(passegers[i], key, Long, TripNowPrice, waiting_time, waiting_price));
                        break;
                    }
                }
            }
            inTrip.Close();
        }*/
        public void OutPutWorkersInFile(List<Workers> workers)
        {
            string pathToPassegers = @"ListOfWorkers.txt";
            StreamWriter inID = new StreamWriter(pathToPassegers);
            foreach (var Val in workers)
            {
                inID.WriteLine(Val.key.ToString() + " " + Val.Name() + " " + Val.SerName() + " " + Val.salaryInOur.ToString() + " " + Val.timeStart.ToShortTimeString() + " " + Val.timeFinish.ToShortTimeString());
            }
            inID.Close();
        }
        public void OutPutPassegersInFile(List<Passeger> passegers)
        {
            string pathToPassegers = @"ListOfPassegers.txt";
            StreamWriter inWork = new StreamWriter(pathToPassegers);
            foreach (var Val in passegers)
            {
                inWork.WriteLine(Val.key.ToString() + " " + Val.Name() + " " + Val.SerName() + " " + Val.countTrips);
            }
            inWork.Close();
        }
        public void OutPutListOfTripsInTheFile(List<Trips> trips)
        {
            string pathToPassegers = @"ListOfTrips.txt";
            StreamWriter ToTrips = new StreamWriter(pathToPassegers);
            for (int i = 0; i < trips.Count(); i++)
            {
                if (i != trips.Count() - 1)
                    ToTrips.WriteLine(trips[i].key_of_passeger.ToString() + " " + trips[i].kilometrs.ToString() + " " + trips[i].priceForOneKilometr.ToString() + " " + trips[i].waitTime.ToString() + " " + trips[i].waitPrice.ToString());
                else
                {
                    ToTrips.Write(trips[i].key_of_passeger.ToString() + " " + trips[i].kilometrs.ToString() + " " + trips[i].priceForOneKilometr.ToString() + " " + trips[i].waitTime.ToString() + " " + trips[i].waitPrice.ToString());
                }
            }
            ToTrips.Close();
        }
    }
}
