using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class OverBookedExeption : Exception
    {
        public OverBookedExeption(string message):base(message)
        {

        }
    }
   public class TourDontExistsExeption : Exception
    {
        public TourDontExistsExeption(string message): base(message)
        {

        }
    }
    public class TourAllocationException : Exception
    {
    }
}
