using NUnit.Framework;
using System;
using System.Collections.Generic;
using TravelAgency;

namespace TravelAgency.Tests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private BookingSystem sut;
        private TourScheduleStub tourSchedule { get; set; }

        private Passenger TestPassenger;

        [SetUp]
        public void Setup()
        {
            tourSchedule = new TourScheduleStub();
            sut = new BookingSystem(tourSchedule);
            TestPassenger = new Passenger()
            {
                FirstName = "Olle",
                LastName = "Svensson",
            };

        }
        [Test]
        public void CanCreateBooking()
        {
            // Arrange
            tourSchedule.Tours.Add(new Tour("In to the roots", new DateTime(2018, 1, 1), 20));

            // Act
            sut.CreateBooking("In to the roots", new DateTime(2018, 1, 1), 20, TestPassenger);
            List<Booking> bookings = sut.GetBookingsFor(TestPassenger);

            //Assert
            Assert.AreEqual(1, bookings.Count);
        }
        [Test]
        public void ThorwExeptionIfTryBookOnNonExistentTour()
        {
            Assert.Throws<TourDontExistsExeption>(() =>
            {
                sut.CreateBooking("In to the roots", new DateTime(2018, 1, 1), 20, TestPassenger);
            });
        }
        [Test]
        public void ThrowExeptionIfOverBookSeats()
        {
            tourSchedule.Tours.Add(new Tour("In to the roots", new DateTime(2018, 1, 1), 1));
            Assert.Throws<OverBookedExeption>(() =>
            {
                sut.CreateBooking("In to the roots", new DateTime(2018, 1, 1), 2, TestPassenger);
            });
        }
        [Test]
        public void CanCancelBooking()
        {
            //Arrange
            tourSchedule.Tours.Add(new Tour("In to the roots", new DateTime(2018, 1, 1), 20));
            sut.CreateBooking("In to the roots", new DateTime(2018, 1, 1), 1, TestPassenger);
            //Act
            sut.CancelBooking("In to the roots", new DateTime(2018, 1, 1), 1, TestPassenger);
            List<Booking> bookings = sut.GetBookingsFor(TestPassenger);
            //Assert
            Assert.AreEqual(0, bookings.Count);
        }
    }
   
    /*   
   In tests such as CanCreateBooking, we also expect the GetToursFor to be called with thecorrect
   DateTime . In your stub, add another list that records the DateTime argument passed
   to GetToursFor every time it's called.
   
   Add assertions to the end of the tests where you expect GetToursFor to be called.
   Assert that it was called the expected number of times, and with the expected argument.
 */

    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours { get; set; }
        public TourScheduleStub()
        {
            Tours = new List<Tour>();
        }

        public void CreateTour(string name, DateTime date, int seats)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            return Tours;
        }
    }
}
