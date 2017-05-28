using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Passenger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static bool operator ==(Passenger p1,Passenger p2)
        {
            if(p1 == p2)
            return true;

            if(p1.FirstName == p2.FirstName &&
                p1.LastName == p2.LastName)
            {
                return true;
            }

            return false;
        }
        public static bool operator !=(Passenger p1, Passenger p2)
        {
            if (p1 == p2) return false;

            return true;
        }
    }
}
