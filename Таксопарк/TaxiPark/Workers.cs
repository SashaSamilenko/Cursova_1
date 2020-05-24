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
        public static event DelegAdd EventAdd;//Подія додавання елемента
        public static event DelegDel EventDelete;//Подія видалення елемента
        public double salaryInOur { get; set; }//заробітня плата за годину
        public double timeInWeek { get; set;}//кількість роботи за тиждень
        public DateTime timeStart{ get; set; }//час початку роботи
        public DateTime timeFinish { get; set; }//значення часу закінчення роботи
        public int key { get; set; }//значення ключа
        //Конструктор з параметрами
        public Workers(DelegAdd eventAdd,DelegDel eventDelete) 
        {
            Workers.EventDelete = (eventDelete!=null) ? eventDelete : null;
            Workers.EventAdd = (eventAdd != null) ? eventAdd : null;
        }
        //Перевизначення методу повернення вартості, у даному випадку заробітної плати працівника (людини)
        public override double ToPay()
        {
            return 5* salaryInOur*((Convert.ToDouble(timeFinish.Hour) + Convert.ToDouble(timeFinish.Minute) / 60) - (Convert.ToDouble(timeStart.Hour) + Convert.ToDouble(timeStart.Minute) / 60));
        }
        //Видалення старого робітника  (водія)
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
        //Додавання нового водія(робітника)
        public static void Add(List<Workers> workers,string name,string sername,double salary,DateTime timeOfStarting, DateTime timeOfFinishing,DelegDel delF,DelegAdd addF)
        {
            int countofList = workers[workers.Count() - 1].key;
            workers.Add(new Workers(addF,delF) { key = countofList + 1, name = name, sername = sername, salaryInOur = salary, timeStart = timeOfStarting, timeFinish = timeOfFinishing });
            Workers.EventAdd?.Invoke();
        }
    }
}
