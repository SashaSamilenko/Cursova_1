using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiParks;
using System.IO;

namespace MainProgect
{
    class Program
    {
        // Головна програма
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
            Menu();
            short c;
            Console.Write("Choose an item of the Menu: ");
            c = short.Parse(Console.ReadLine());
            while (true)
            {
                switch (c)
                {
                    case 1: Console.Clear(); Passeger_Doing_Menu(listOfPassegers, listOfNowTrips); Menu(); Console.Write("Choose an item of the Menu: ");  c = short.Parse(Console.ReadLine()); break;
                    case 2: Console.Clear(); Trips_Doing_Menu(listOfPassegers, listOfNowTrips); Menu(); Console.Write("Choose an item of the Menu: ");  c = short.Parse(Console.ReadLine()); break;
                    case 3: Console.Clear(); Workers_Doing_Menu(listOfWorkers); Menu(); Console.Write("Choose an item of the Menu: ");  c = short.Parse(Console.ReadLine()); break;
                    case 4: Console.Clear(); AboutMe(); Menu(); Console.Write("Choose an item of the Menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 5: Console.Clear(); Environment.Exit(0); break;
                    default:
                        Console.Clear();
                        Menu();
                        Console.WriteLine("You inputed not right value of the item!");
                        Console.Write("Select an item of menu again: ");
                        c = short.Parse(Console.ReadLine());
                        break;
                }
            }
            Console.ReadKey();
        }
        //Метод для виводу інформацію про робітників
        public static void WorkersInformationOfList(List<Workers> kind)
        {
            Console.WriteLine("\t\tList of workers:");
            Console.WriteLine("Key".PadRight(15)+"Name".PadRight(15) + "Sername".PadRight(15) + "All salary in the week".PadRight(25) + "TimeToStart".PadRight(15) + "TimeToFinish".PadRight(15));
            foreach (var Obj in kind)
            {
                Console.WriteLine(Obj.key.ToString().PadRight(15)+Obj.Name().PadRight(15) + Obj.SerName().PadRight(15) + Math.Round(Obj.ToPay(), 2).ToString() + "$".PadRight(25 - Math.Round(Obj.ToPay(), 2).ToString().Length) + Obj.timeStart.ToShortTimeString().PadRight(15) + Obj.timeFinish.ToShortTimeString().PadRight(15));
            }
        }
        //Метод для виводу інформацію про пасажирів
        public static void PassegersInformation(List<Passeger> passeger)
        {
            Console.WriteLine($"\t\tList of passegers:");
            Console.WriteLine("Key".PadRight(15) + "Name".PadRight(15) + "Sername".PadRight(15) + "Count of trips".PadRight(15));
            foreach (var Obj in passeger)
            {
                Console.WriteLine(Obj.key.ToString().PadRight(15) + Obj.Name().PadRight(15) + Obj.SerName().PadRight(15) + Obj.countTrips.ToString().PadRight(15));
            }
        }
        //Метод для виводу інформацію про поїздки
        public static void TripsInformation(List<Trips> listOfNowTrips)
        {
            Console.WriteLine("\t\tList of trips");
            Console.WriteLine("Key".PadRight(15)+$"Name".PadRight(15) + "Sername".PadRight(15) + "Price".PadRight(15) + "Long".PadRight(15) + "TimeInWaiting".PadRight(15));
            foreach (var Obj in listOfNowTrips)
            {
                Console.WriteLine(Obj.key_of_passeger.ToString().PadRight(15)+Obj.Name().PadRight(15) + Obj.SerName().PadRight(15) + Math.Round(Obj.ToPay(), 2).ToString() + "$".PadRight(15 - Math.Round(Obj.ToPay(), 2).ToString().Length) + Obj.kilometrs.ToString().PadRight(15) + Obj.waitTime.ToString() + "(hour.)".PadRight(15 - Obj.waitTime.ToString().Length));
            }
        }
        //Метод для пошуку пасажирів
        public static void FindPasseger(List<Passeger> passeger)
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
        //Метод для пошуку Поїздок
        public static void FindTrips(List<Trips> trips)
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
        //Метод для пошуку водіїв
        public static void FindWorker(List<Workers> workers)
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
        //Метод для того, щоб зчитувати дані про водіїв з файлу
        public static void InputWorkers(ref List<Workers> listWorkers)
        {
            string pathToWorkers = @"ListOfWorkers.txt";
            FileInfo fileInf = new FileInfo(pathToWorkers);
            StreamReader inWork = new StreamReader(pathToWorkers);
            string wors = inWork.ReadToEnd();
            int files_count = 0;
            int lenght = Convert.ToInt32(fileInf.Length);
            while (files_count < lenght)
            {
                DelegDel delegDel;
                DelegAdd delegAdd;
                delegAdd = InfoAddWorkers;
                delegDel = InfoPopWorkers;
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
                listWorkers.Add(new Workers(delegAdd,delegDel) { key = key, name = name, sername = sername, salaryInOur = salary, timeStart = DateTime.Parse(dateofStart), timeFinish = DateTime.Parse(dateofFinish) });
            }
            inWork.Close();
        }
        //Метод для того, щоб зчитувати дані про пасажирів з файлу
        public static void InputPasseger(ref List<Passeger> listOfPassegers)
        {
            DelegDel delegDel;
            DelegAdd delegAdd;
            delegAdd = InfoAddPassegers;
            delegDel = InfoPopPassegers;
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
                listOfPassegers.Add(new Passeger(name, sername, count_of_trips, key,delegAdd,delegDel));
            }
            inWork.Close();
        }
        //Метод для того, щоб зчитувати діні про поїздки з файлу
        public static void InputNowListOfTrips(ref List<Trips> ArrgOfTrips, List<Passeger> passegers)
        {
            DelegDel delegDel;
            DelegAdd delegAdd;
            delegAdd = InfoAddTrips;
            delegDel = InfoPopTrips;
            DelegOutPut OutPutTOFileDeleg = OutPutListOfTripsInTheFile;
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
                        ArrgOfTrips.Add(new Trips(passegers[i], key, Long, TripNowPrice, waiting_time, waiting_price,OutPutTOFileDeleg,delegAdd,delegDel));
                        break;
                    }
                }
            }
            inTrip.Close();
        }
        //Вивід даних про робітників у файл
        public static void OutPutWorkersInFile(List<Workers> workers)
        {
            string pathToPassegers = @"ListOfWorkers.txt";
            StreamWriter inID = new StreamWriter(pathToPassegers);
            foreach (var Val in workers)
            {
                inID.WriteLine(Val.key.ToString() + " " + Val.Name() + " " + Val.SerName() + " " + Val.salaryInOur.ToString() + " " + Val.timeStart.ToShortTimeString() + " " + Val.timeFinish.ToShortTimeString());
            }
            inID.Close();
        }
        //Вивід даних про пасажирів у файл
        public static void OutPutPassegersInFile(List<Passeger> passegers)
        {
            string pathToPassegers = @"ListOfPassegers.txt";
            StreamWriter inWork = new StreamWriter(pathToPassegers);
            foreach (var Val in passegers)
            {
                inWork.WriteLine(Val.key.ToString() + " " + Val.Name() + " " + Val.SerName() + " " + Val.countTrips);
            }
            inWork.Close();
        }
        //Вивід даних про поїздки у файл
        public static void OutPutListOfTripsInTheFile(List<Trips> trips)
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
        //Метод для видалення поїздки
        static public void deleteTrip(List<Trips> trips)
        {
            Console.Write("Key = ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            Trips.Delete(name, sername, key, trips);
            OutPutListOfTripsInTheFile(trips);
        }
        //Метод для видалення робітника
        static public void deleteWorker(List<Workers> workers)
        {
            Console.Write("key = ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            Workers.Delete(workers, name, sername, key);
            OutPutWorkersInFile(workers);
        }
        //Метод для видалення пасажира
        static public void deletePasseger(List<Passeger> passegers, List<Trips> trips)
        {
            Console.Write("Key = ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
            Passeger.Delete(trips, passegers, name, sername,key);
            OutPutPassegersInFile(passegers);
            OutPutListOfTripsInTheFile(trips);
        }
        //Метод для додавання нового пасажира
        static public void AddNewPasseger(List<Passeger> pass)
        {
            Console.Write("New name: ");
            string name = Console.ReadLine();
            Console.Write("New Sername: ");
            string sername = Console.ReadLine();
            Console.Write("Do you want to describe to news about adding this person(YES - input: true, if NO - input -false: ");
            bool BDelegAdd = bool.Parse(Console.ReadLine());
            DelegAdd delegAdd = null;
            if (BDelegAdd==true)
            {
                delegAdd = InfoAddPassegers;
            }
            Console.Write("Do you want to describe to news about deletting this person(YES - input: true, if NO - input -false: ");
            bool BDelegDel = bool.Parse(Console.ReadLine());
            DelegDel delegDel = null;
            if (BDelegDel == true)
            {
                delegDel = InfoPopPassegers;
            }
            Passeger.Add(pass, name, sername,delegAdd,delegDel);
            OutPutPassegersInFile(pass);
        }
        //Метод для додавання нової поїздки
        static public void AddTrip(List<Trips> NTrip, List<Passeger> passegers)
        {
            DelegOutPut OutPutToFile = OutPutListOfTripsInTheFile;
            Console.Write("Key = ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Sername: ");
            string sername = Console.ReadLine();
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
            Console.Write("Do you want to describe to news about adding this trip(YES - input: true, if NO - input -false: ");
            bool BDelegAdd = bool.Parse(Console.ReadLine());
            DelegAdd delegAdd = null;
            if (BDelegAdd == true)
            {
                delegAdd = InfoAddTrips;
            }
            Console.Write("Do you want to describe to news about deletting this trip(YES - input: true, if NO - input -false: ");
            bool BDelegDel = bool.Parse(Console.ReadLine());
            DelegDel delegDel = null;
            if (BDelegDel == true)
            {
                delegDel = InfoPopTrips;
            }
            Trips.Add(passegers, NTrip, name, sername, key, Long, PriceForOneKilometr, waiting_time, waiting_price,OutPutToFile,delegAdd,delegDel);
            OutPutListOfTripsInTheFile(NTrip);
            OutPutPassegersInFile(passegers);
        }
        //Метод для додавання нового водія
        static public void AddNewWorker(List<Workers> workers)
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
                Console.Write("Date of starting: ");
                DateTime timeOfStarting = DateTime.Parse(Console.ReadLine());
                Console.Write("Date of finishing: ");
                DateTime timeOfFinishing = DateTime.Parse(Console.ReadLine());
            Console.Write("Do you want to describe to news about adding this person(YES - input: true, if NO - input -false: ");
            bool BDelegAdd = bool.Parse(Console.ReadLine());
            DelegAdd delegAdd = null;
            if (BDelegAdd == true)
            {
                delegAdd = InfoAddWorkers;
            }
            Console.Write("Do you want to describe to news about deletting this person(YES - input: true, if NO - input -false: ");
            bool BDelegDel = bool.Parse(Console.ReadLine());
            DelegDel delegDel = null;
            if (BDelegDel == true)
            {
                delegDel = InfoPopWorkers;
            }
            Workers.Add(workers, name, sername, salary, timeOfStarting, timeOfFinishing,delegDel,delegAdd);
                OutPutWorkersInFile(workers);
        }
        //Метод для виводу інформації додавання Робітників
        static public void InfoAddWorkers()
        {
            Console.WriteLine("Worker was add!");
        }
        //Метод для виводу інформації додавання Поїздок
        static public void InfoAddTrips()
        {
            Console.WriteLine("Trip was add!");
        }
        //Метод для вивіду ітформації додавання Пасажирів
        static public void InfoAddPassegers()
        {
            Console.WriteLine("Passeger was add!");
        }
        //Метод для виводу інформації видалення Робітників
        static public void InfoPopWorkers()
        {
            Console.WriteLine("Worker was delete!");
        }
        //Метод для виводу інформації видалення Поїздок
        static public void InfoPopTrips()
        {
            Console.WriteLine("Trip was delete!");
        }
        //Метод для виводу інформації видалення Пасажирів
        static public void InfoPopPassegers()
        {
            Console.WriteLine("Passeger was delete!");
        }

        //Вивід у консоль головного меню
        static public void Menu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. Come to menu for passegers");
            Console.WriteLine("2. Come to menu for trips");
            Console.WriteLine("3. Come to menu for workers");
            Console.WriteLine("4. About author! ");
            Console.WriteLine("5. Exit!");
        }
        //Вивід інформацію про автора курсової роботи
        static public void AboutMe()
        {
            Console.WriteLine("Sername: Samilenko\nName: Oleksandr");
            Console.WriteLine("First course");
            Console.WriteLine("Group of: IS-93");
        }
        //Метод для реалізації роботи з меню для пасажирів
        static public void Passeger_Doing_Menu(List<Passeger> listOfPassegers, List<Trips> listOfNowTrips )
        {
            Passeger_Menu();
            short c;
            Console.Write("Select an item of the menu - ");
            c = short.Parse(Console.ReadLine());
            bool flag = true;
            while (flag==true)
            {
                switch (c)
                {
                    case 1: Console.Clear(); PassegersInformation(listOfPassegers); Passeger_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 2: Console.Clear(); AddNewPasseger(listOfPassegers); Passeger_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 3: Console.Clear(); PassegersInformation(listOfPassegers); deletePasseger(listOfPassegers, listOfNowTrips); Passeger_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 4: Console.Clear(); FindPasseger(listOfPassegers); Passeger_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 5: Console.Clear(); flag = false; break;
                    default:
                        Console.Clear();
                        Menu();
                        Console.WriteLine("You inputed not right value of the item!");
                        Console.Write("Select an item of menu again: ");
                        c = short.Parse(Console.ReadLine());
                        break;
                }
            }
        }
        //Метод для реалізації роботи з меню поїздок
        static public void Trips_Doing_Menu(List<Passeger> listOfPassegers, List<Trips> listOfNowTrips)
        {
            Trips_Menu();
            short c;
            Console.Write("Select an item of the menu - ");
            c = short.Parse(Console.ReadLine());
            bool flag = true;
            while (flag)
            {
                switch (c)
                {
                    case 1: Console.Clear(); TripsInformation(listOfNowTrips); Trips_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 2: Console.Clear(); PassegersInformation(listOfPassegers);  AddTrip(listOfNowTrips,listOfPassegers); Trips_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 3: Console.Clear(); TripsInformation(listOfNowTrips); deleteTrip(listOfNowTrips); Trips_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 4: Console.Clear(); FindTrips(listOfNowTrips); Trips_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 5: Console.Clear(); flag = false; break;
                    default:
                        Console.Clear();
                        Menu();
                        Console.WriteLine("You inputed not right value of the item!");
                        Console.Write("Select an item of menu again: ");
                        c = short.Parse(Console.ReadLine());
                        break;
                }
            }
        }
        //Метод для реалізації роботи з меню поїздок
        static public void Workers_Doing_Menu(List<Workers> listOfWorkers)
        {
            Workers_Menu();
            short c;
            Console.Write("Select an item of the menu - ");
            c = short.Parse(Console.ReadLine());
            bool flag = true;
            while (flag)
            {
                switch (c)
                {
                    case 1: Console.Clear(); WorkersInformationOfList(listOfWorkers);  Workers_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 2: Console.Clear(); AddNewWorker(listOfWorkers); Workers_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 3: Console.Clear(); WorkersInformationOfList(listOfWorkers); deleteWorker(listOfWorkers); Workers_Menu(); Console.Write("Select an item of the menu: "); c = short.Parse(Console.ReadLine()); break;
                    case 4: Console.Clear(); FindWorker(listOfWorkers); Workers_Menu(); Console.Write("Select an item of the menu: ");  c = short.Parse(Console.ReadLine()); break;
                    case 5: Console.Clear(); flag = false; break;
                    default:
                        Console.Clear();
                        Menu();
                        Console.WriteLine("You inputed not right value of the item!");
                        Console.Write("Select an item of menu again: ");
                        c = short.Parse(Console.ReadLine());
                        break;
                }
            }
        }
        //Вивід меню пасажирів
        static public void Passeger_Menu()
        {
            Console.WriteLine("Passeger`s menu");
            Console.WriteLine("1. OutPut list of passegers");
            Console.WriteLine("2. Add new a passeger");
            Console.WriteLine("3. Delete the passeger");
            Console.WriteLine("4. Find the passeger");
            Console.WriteLine("5. Return to main menu!");
        }
        //Вивід меню для поїздок
        static public void Trips_Menu()
        {
            Console.WriteLine("Trip`s menu");
            Console.WriteLine("1. OutPut list of trips");
            Console.WriteLine("2. Add new a trip");
            Console.WriteLine("3. Delete the trip");
            Console.WriteLine("4. Find the trip");
            Console.WriteLine("5. Return to main menu!");
        }
        //Вивід меню для робітників - водіїв
        static public void Workers_Menu()
        {
            Console.WriteLine("Worker`s menu");
            Console.WriteLine("1. OutPut list of workers");
            Console.WriteLine("2. Add new a new worker");
            Console.WriteLine("3. Delete the worker");
            Console.WriteLine("4. Find the worker");
            Console.WriteLine("5. Return to main menu!");
        }
    }
}