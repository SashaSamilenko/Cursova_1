using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
    public interface ITrips
    {
        double ToPay();
        string Name();
        string SerName();
    }
}
