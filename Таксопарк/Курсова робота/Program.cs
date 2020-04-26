using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiPark;
using System.IO;

namespace MainProgect
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input list of workers
            var listOfWorkers = new List<Workers>();
            InputWorkers(ref listOfWorkers);
            //Make list of passeger
            var listOfPassegers = new List<Passeger>();
            InputPasseger(ref listOfPassegers);
            //List of trips
            var listOfNowTrips = new List<Trips>();
            InputNowListOfTrips(ref listOfNowTrips, listOfPassegers);
            //Take information of a values in progect!!++++
            Information info = new Information();
            info.WorkersInformationOfList(listOfWorkers);
            info.TripsInformation(listOfNowTrips);
            info.PassegersInformation(listOfPassegers);
            AddNewWorker(ref listOfWorkers);
            Console.ReadKey();
        }
        static public void deleteWorker(List<Workers> workers)
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            bool flag = false;
            foreach(var worker in workers)
            {
                if(worker.name==name && worker.sername==sername)
                {
                    flag = true;
                    workers.Remove(worker);
                    break;
                }
            }
            if(flag==false)
            {
                throw new ArgumentException("Did not find this person!");
            }
            OutPutWorkersInFile(workers);
        }
        static public void deleteTrip(List<Trips> trips)
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            bool flag = false;
            foreach (var trip in trips)
            {
                if (trip.Name()== name && trip.SerName()== sername)
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
            OutPutListOfTripsInTheFile(trips);
        }
        static public void deletePasseger(List<Passeger> passegers, List<Trips> trips)
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            bool flag = false;
            foreach (var trip in trips)
            {
                if (trip.Name() == name && trip.SerName() == sername)
                {
                    trips.Remove(trip);
                    break;
                }
            }
            foreach (var passeger in passegers)
            {
                if (passeger.name == name && passeger.sername == sername)
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
                        trips[i].index_of_Passeger = passeger.key;
                    }
                }
            }
            OutPutPassegersInFile(passegers);
            OutPutListOfTripsInTheFile(trips);
        }
        static public void AddNewPasseger(ref List<Passeger> pass)
        {
            Console.Write("New name: ");
            string name = Console.ReadLine();
            Console.Write("New Sername: ");
            string sername = Console.ReadLine();
            foreach(var Value in pass)
            {
                if(Value.name==name && Value.sername==sername)
                {
                    throw new ArgumentException("This passeger yet in Date");
                }
            }
            int countofList = pass.Count();
            pass.Add(new Passeger(name, sername, 0, countofList));
            OutPutPassegersInFile(pass);
        }
        static public void AddNewWorker(ref List<Workers> workers)
        {
            Console.Write("New name: ");
            string name = Console.ReadLine();
            Console.Write("New Sername: ");
            string sername = Console.ReadLine();
            foreach (var Value in workers)
            {
                if (Value.name == name && Value.sername == sername)
                {
                    throw new ArgumentException("This passeger yet in Date");
                }
            }
            Console.Write("salaryInOur: ");
            double salary = Convert.ToDouble(Console.ReadLine());
            if(salary<=0)
            {
                throw new ArgumentNullException("Salary must be more than zero!!!");
            }
            Console.WriteLine("Date of starting: ");
            DateTime timeOfStarting = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Date of finishing: ");
            DateTime timeOfFinishing = DateTime.Parse(Console.ReadLine());
            int countofList = workers.Count();
            workers.Add(new Workers() { name = name, sername = sername, salaryInOur = salary, timeStart = timeOfStarting, timeFinish = timeOfFinishing });
            OutPutWorkersInFile(workers);
        }
        static public void AddTrip(ref List<Trips> NTrip,List<Passeger> passegers)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            foreach (var val in NTrip)
            {
                if (val.Name() == name && val.SerName() == sername)
                {
                    throw new ArgumentException("This passeger yet in way!");
                }
            }
            Console.Write("Long:");
            double Long = Convert.ToDouble(Console.ReadLine());
            if(Long<=0)
            {
                throw new ArgumentNullException("Long must be more than zero!!!");
            }
            Console.Write("Price for one kilimert: ");
            double PriceForOneKilometr = Convert.ToDouble(Console.ReadLine());
            if(PriceForOneKilometr<=0)
            {
                throw new ArithmeticException("Price for a one kilometrs should be more than 0!");
            }
            Console.Write("Waiting time: ");
            double waiting_time = Convert.ToDouble(Console.ReadLine());
            if(waiting_time<0)
            {
                throw new ArgumentException("Waiting time must be >= 0");
            }
            Console.Write("Waiting price: ");
            double waiting_price = Convert.ToDouble(Console.ReadLine());
            if(waiting_price<0)
            {
                throw new ArgumentException("Price for a waiting should be more than zero or is equal with zero!!!");
            }
            int indexofPasseger = 0;
            bool flag = false;
            foreach(var Value in passegers)
            {
                if(Value.name==name && Value.sername==sername)
                {
                    indexofPasseger = Value.key;
                    NTrip.Add(new Trips(passegers[indexofPasseger],passegers[passegers.Count()-1].key+1, Long, PriceForOneKilometr, waiting_time, waiting_price));
                    OutPutListOfTripsInTheFile(NTrip);
                    flag = true;
                    break;
                }
            }
            if(flag==false)
            {
                throw new ArgumentException("Warning: This passeger did not find. You can to try this: add new passeger.");
            }
        }
        static public void InputWorkers(ref List<Workers> listWorkers)
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
                            case 1: name = s; break;
                            case 2: sername = s; break;
                            case 3: salary = Convert.ToDouble(s); break;
                            case 4: dateofStart = s; break;
                            case 5: dateofFinish = s; break;
                        }
                        k_space += 1;
                        s = "";
                    }
                    else
                    {
                        s += c;
                    }
                }
                listWorkers.Add(new Workers() { name = name, sername = sername, salaryInOur = salary, timeStart = DateTime.Parse(dateofStart), timeFinish = DateTime.Parse(dateofFinish) });
            }
            inWork.Close();
        }
        static public void InputPasseger(ref List<Passeger> listOfPassegers)
        {
            string pathToPassegers = @"ListOfPassegers.txt";
            FileInfo fileInf = new FileInfo(pathToPassegers);
            StreamReader inWork = new StreamReader(pathToPassegers);
            string wors = inWork.ReadToEnd();
            int files_count = 0;
            int lenght = Convert.ToInt32(fileInf.Length);
            int indexw = 0;
            while (files_count < lenght)
            {
                string name = "\0", sername = "\0";
                int count_of_trips = 0;
                string s = "";
                char c = ' ';
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
                            case 1: name = s; break;
                            case 2: sername = s; break;
                            case 3: count_of_trips = Convert.ToInt32(s); break;
                        }
                        k_space += 1;
                        s = "";
                    }
                    else
                    {
                        s += c;
                    }
                }
                listOfPassegers.Add(new Passeger(name, sername, count_of_trips, indexw));
                indexw += 1;
            }
            inWork.Close();
        }
        static public void InputNowListOfTrips(ref List<Trips> ArrgOfTrips, List<Passeger> passegers)
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
                int index_passeger = 0;
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
                            case 1: key = Convert.ToInt32(s);break;
                            case 2: index_passeger = Convert.ToInt32(s); break;
                            case 3: Long = Convert.ToDouble(s); break;
                            case 4: TripNowPrice = Convert.ToDouble(s); break;
                            case 5: waiting_time = Convert.ToDouble(s); break;
                            case 6: waiting_price = Convert.ToDouble(s); break;
                        }
                        k_space += 1;
                        s = "";
                    }
                    else
                    {
                        s += c;
                    }
                }
                ArrgOfTrips.Add(new Trips(passegers[index_passeger],key, Long, TripNowPrice, waiting_time, waiting_price));
            }
            inTrip.Close();
        }
        static public void OutPutWorkersInFile(List<Workers> workers)
        {
            string pathToPassegers = @"ListOfWorkers.txt";
            StreamWriter inID = new StreamWriter(pathToPassegers);
            foreach (var Val in workers)
            {
                inID.WriteLine(Val.name + " " + Val.sername + " " + Val.salaryInOur.ToString() + " " + Val.timeStart.ToShortTimeString() + " " + Val.timeFinish.ToShortTimeString());
            }
            inID.Close();
        }
        static public void OutPutPassegersInFile(List<Passeger> passegers)
        {
            string pathToPassegers = @"ListOfPassegers.txt";
            StreamWriter inWork = new StreamWriter(pathToPassegers);
            foreach (var Val in passegers)
            {
                inWork.WriteLine(Val.name + " " + Val.sername + " " + Val.countTrips);
            }
            inWork.Close();
        }
        static public void OutPutListOfTripsInTheFile(List<Trips> trips)
        {
            string pathToPassegers = @"ListOfTrips.txt";
            StreamWriter ToTrips = new StreamWriter(pathToPassegers);
            for (int i = 0; i < trips.Count(); i++)
            {
                if (i != trips.Count() - 1)
                    ToTrips.WriteLine(trips[i].index_of_Passeger.ToString() + " " + trips[i].kilometrs.ToString() + " " + trips[i].priceForOneKilometr.ToString() + " " + trips[i].waitTime.ToString() + " " + trips[i].waitPrice.ToString());
                else
                {
                    ToTrips.Write(trips[i].index_of_Passeger.ToString() + " " + trips[i].kilometrs.ToString() + " " + trips[i].priceForOneKilometr.ToString() + " " + trips[i].waitTime.ToString() + " " + trips[i].waitPrice.ToString());
                }
            }
            ToTrips.Close();
        }
    }
}