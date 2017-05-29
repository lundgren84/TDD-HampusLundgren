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
        private List<Booking> Bookings { get; set; } = new List<Booking>();

        public BookingSystem(ITourSchedule tourSchedule)
        {
            this.tourSchedule = tourSchedule;

        }

        public List<Booking> GetBookingsFor(Passenger passenger)
        {
            return Bookings.Where(x => x.passenger.FirstName == passenger.FirstName &&
                                       x.passenger.LastName == passenger.LastName).ToList();
        }

        public void CreateBooking(string v1, DateTime dateTime, int v2, Passenger passenger)
        {
            Bookings.Add(new Booking()
            {
                tourName = v1,
                passenger = passenger,
                seats = v2,
                date = dateTime,
            });
        }
    }




}
