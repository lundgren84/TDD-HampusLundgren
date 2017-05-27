using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class BookingSystem
    {
        private ITourSchedule tourSchedule;
      

        public BookingSystem(ITourSchedule tourSchedule)
        {
            this.tourSchedule = tourSchedule;
         
        }
    }
}
