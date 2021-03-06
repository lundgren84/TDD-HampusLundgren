﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using NSubstitute;

namespace TravelAgency.Tests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private BookingSystem sut;
        private TourScheduleStub tourSchedule { get; set; }


        private IMailSender mailSender { get; set; }
        //Test props
        private Passenger TestPassenger;
        private DateTime TestDate;

        [SetUp]
        public void Setup()
        {
            mailSender = Substitute.For<IMailSender>();
            tourSchedule = new TourScheduleStub();
            sut = new BookingSystem(tourSchedule, mailSender);

            TestDate = new DateTime(2018, 1, 1);
            TestPassenger = new Passenger()
            {
                FirstName = "Olle",
                LastName = "Svensson",
                Email = "ollesvensson@gmail.com",
            };

        }
        [Test]
        public void CanCreateBooking()
        {
            // Arrange
            tourSchedule.Tours.Add(new Tour("In to the roots", TestDate, 20));

            // Act
            sut.CreateBooking("In to the roots", TestDate, 20, TestPassenger);
            List<Booking> bookings = sut.GetBookingsFor(TestPassenger);

            //Assert
            Assert.AreEqual(1, bookings.Count);
        }
        [Test]
        public void ThorwExeptionIfTryBookOnNonExistentTour()
        {
            Assert.Throws<TourDontExistsExeption>(() =>
            {
                sut.CreateBooking("In to the roots", TestDate, 20, TestPassenger);
            });
        }
        [Test]
        public void ThrowExeptionIfOverBookSeats()
        {
            tourSchedule.Tours.Add(new Tour("In to the roots", TestDate, 1));
            Assert.Throws<OverBookedExeption>(() =>
            {
                sut.CreateBooking("In to the roots", TestDate, 2, TestPassenger);
            });
        }
        [Test]
        public void CanCancelBooking()
        {
            //Arrange
            tourSchedule.Tours.Add(new Tour("In to the roots", TestDate, 20));
            sut.CreateBooking("In to the roots", TestDate, 1, TestPassenger);
            //Act
            sut.CancelBooking("In to the roots", TestDate, 1, TestPassenger);
            List<Booking> bookings = sut.GetBookingsFor(TestPassenger);
            //Assert
            Assert.AreEqual(0, bookings.Count);
        }
        [Test]
        public void ConfirmationMailSentWhenBookingTour()
        {
            //Arrange
            tourSchedule.Tours.Add(new Tour("In to the roots", TestDate, 20));
            //Act
            sut.CreateBooking("In to the roots", TestDate, 1, TestPassenger);
            //Assert
            sut.mailSender.Received().Send(Arg.Any<string>(), Arg.Any<string>());

        }
        [Test]
        public void ConfirmationMailContainsAllBookingInformation()
        {
            /* Exercise 5
             9.	Add another test to make sure that the email message contains both the date and the name of the booked tour. Make the test pass.  */

            //Arrange
            tourSchedule.Tours.Add(new Tour("In to the roots", TestDate, 20));
            //Act
            sut.CreateBooking("In to the roots", TestDate, 1, TestPassenger);
            //Assert
            sut.mailSender.Received().Send(TestPassenger.Email,
                Arg.Is<string>(x => x.Contains(TestDate.ToString()) && x.Contains("In to the roots")));

        }
    }



    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours { get; set; }
        public List<DateTime> Dates { get; set; }
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
            Dates.Add(dateTime);
            return Tours;
        }
    }
}
