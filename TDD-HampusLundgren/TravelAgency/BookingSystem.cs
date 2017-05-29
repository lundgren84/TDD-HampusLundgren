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
        public IMailSender mailSender;

        private List<Booking> Bookings { get; set; } = new List<Booking>();

        public BookingSystem(ITourSchedule tourSchedule)
        {
            this.tourSchedule = tourSchedule;

        }

        public BookingSystem(ITourSchedule tourSchedule, IMailSender mailSender) 
        {
            this.tourSchedule = tourSchedule;
            this.mailSender = mailSender;
        }

        public List<Booking> GetBookingsFor(Passenger passenger)
        {
            return Bookings.Where(x => x.passenger.FirstName == passenger.FirstName &&
                                       x.passenger.LastName == passenger.LastName).ToList();
        }

        public void CreateBooking(string tourName, DateTime dateTime, int seats, Passenger passenger)
        {
            var tour = tourSchedule.Tours.FirstOrDefault(x => x.Name == tourName);
            if (tour == null)
            {
                throw new TourDontExistsExeption("This tour dont exists.");
            }
            if (tour.Seats< seats)
            {
                throw new OverBookedExeption("The number of seats asked is not avalible. Seats avalible: "+tour.Seats+". Seats askef for: "+seats+".");
            }    
            
            Bookings.Add(new Booking()
            {
                tourName = tourName,
                passenger = passenger,
                seats = seats,
                date = dateTime,
            });
            mailSender.Send(passenger.Email, "Thank you for book this crap.");
        }

        public void CancelBooking(string name, DateTime date, int seats, Passenger passenger)
        {
            var booking = Bookings.FirstOrDefault(x => x.date == date && x.tourName == name &&
            x.seats == seats && x.passenger == passenger);
            if(booking != null)
            {
                Bookings.Remove(booking);
            }
        }
    }




}
