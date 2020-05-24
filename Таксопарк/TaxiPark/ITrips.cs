using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiParks
{
    public interface ITrips//Інтерфейс
    {
        double ToPay();//Метод ціни
        string Name();//Ім'я
        string SerName();//Фамілії
    }
}
