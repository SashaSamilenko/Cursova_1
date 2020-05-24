using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiParks
{
    public class Discount
    {
        public double discount{ get; set; }//Властивіть скидки
        public int countTrips;//Кількість поїздок
        public Discount(int countTrips)//Конструктор, на вхід якого задається параметр - кількості поїздок
        {
            this.countTrips = countTrips;
        }
        public double ToPay(double hours,double priceOne)//Метод, який повертає вартість повної поїздки
        {
            discount = countTrips % priceOne+9;
            return (priceOne * hours * (1 - discount/89));
        }
    }
}
