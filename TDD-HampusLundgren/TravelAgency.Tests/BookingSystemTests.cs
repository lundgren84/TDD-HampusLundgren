﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Tests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub tourSchedule { get; set; }
        private BookingSystem sut;
       
        [SetUp]
        public void Setup()
        {
            tourSchedule = new TourScheduleStub();
            sut = new BookingSystem(tourSchedule);
            
        }
        [Test]
        public void CanCreateBooking()
        {
            // Arrange
            tourSchedule.Tours.Add(new Tour("In to the roots", new DateTime(2018, 1, 1),20));
            Passenger passenger = new Passenger()
            {
                FirstName = "Olle",
                LastName = "Svensson",
            };
            Booking booking = sut.CreateBooking("In to the roots", new DateTime(2018, 1, 1), 20),passenger);
            List<Booking> bookings = sut.GetBookingsFor(passenger);
            // Act
            //Assert
            Assert.AreEqual(1, bookings.Count);
        }
    }




    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours { get; set; } = new List<Tour>();

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