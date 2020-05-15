using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaxiParks
{
    public class Workers : TaxiPark
    {
        public static event DelegAdd EventAdd;
        public static event DelegDel EventDelete;
        public double salaryInOur { get; set; }
        public double timeInWeek { get; set;}
        public DateTime timeStart{ get; set; }
        public DateTime timeFinish { get; set; }
        public int key { get; set; }
        public Workers(DelegAdd eventAdd,DelegDel eventDelete) 
        {
            Workers.EventDelete = (eventDelete!=null) ? eventDelete : null;
            Workers.EventAdd = (eventAdd != null) ? eventAdd : null;
        }
        public override string Name()
        {
            return base.Name();
        }
        public override string SerName()
        {
            return base.SerName();
        }
        public override double ToPay()
        {
            return 5* salaryInOur*((Convert.ToDouble(timeFinish.Hour) + Convert.ToDouble(timeFinish.Minute) / 60) - (Convert.ToDouble(timeStart.Hour) + Convert.ToDouble(timeStart.Minute) / 60));
        }
        public static void Delete(List<Workers> workers,string name,string sername,int key)
        {
            bool flag = false;
            foreach (var worker in workers)
            {
                if (worker.key == key && worker.Name() == name && worker.SerName() == sername)
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
            Workers.EventDelete?.Invoke();
        }
        public static void Add(List<Workers> workers,string name,string sername,double salary,DateTime timeOfStarting, DateTime timeOfFinishing,DelegDel delF,DelegAdd addF)
        {
            int countofList = workers[workers.Count() - 1].key;
            workers.Add(new Workers(addF,delF) { key = countofList + 1, name = name, sername = sername, salaryInOur = salary, timeStart = timeOfStarting, timeFinish = timeOfFinishing });
            Workers.EventAdd?.Invoke();
        }
    }
}
