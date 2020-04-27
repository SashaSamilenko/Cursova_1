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
            Information info = new Information();
            Edit_informations edit = new Edit_informations();
            //Input list of workers
            var listOfWorkers = new List<Workers>();
            info.InputWorkers(ref listOfWorkers);
            //Make list of passeger
            var listOfPassegers = new List<Passeger>();
            info.InputPasseger(ref listOfPassegers);
            //List of trips
            var listOfNowTrips = new List<Trips>();
            info.InputNowListOfTrips(ref listOfNowTrips, listOfPassegers);
            //Take information of a values in progect!!++++
            info.WorkersInformationOfList(listOfWorkers);
            info.TripsInformation(listOfNowTrips);
            info.PassegersInformation(listOfPassegers);
            info.FindWorker(listOfWorkers);
            edit.AddNewWorker(ref listOfWorkers);
            Console.ReadKey();
        }
    }
}