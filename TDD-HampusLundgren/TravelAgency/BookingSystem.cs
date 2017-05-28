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
        private List<Booking> Bookings;

        public BookingSystem(ITourSchedule tourSchedule)
        {
            this.tourSchedule = tourSchedule;
            this.Bookings = new List<Booking>();
        }
       

        public void CreateBooking(string tourName, DateTime date, int seats, Passenger passenger)
        {
            Bookings.Add(new Booking() {
                passenger = passenger,
                seats = seats,
                date = date,
                tourName = tourName,
            });
        }

        public List<Booking> GetBookingsFor(Passenger passenger)
        {
            return Bookings.Where(x=>x.passenger == passenger).ToList();
        }
    }
}
