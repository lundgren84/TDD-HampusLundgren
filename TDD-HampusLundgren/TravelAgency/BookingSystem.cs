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

        public Booking CreateBooking(string v1, DateTime dateTime, int v2)
        {
            throw new NotImplementedException();
        }    

        public Booking CreateBooking(string v1, DateTime date, int seats, Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetBookingsFor(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
