using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiParks
{
    public abstract class TaxiPark:ITrips
    {
        public string name { private get; set; }//Властивість імені
        public string sername { private get; set; }//Властивість фамілії
        //Повернення ім'я
        public virtual string Name()
        {
            return name;
        }
        //Повернення фамілії
        public virtual string SerName()
        {
            return sername;
        }
        //Повернення ціни/вартості
        public virtual double ToPay()
        {
            return 0;
        }
    }
}