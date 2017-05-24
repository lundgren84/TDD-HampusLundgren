using NUnit.Framework;
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
        private ITourSchedule sut { get; set; }
       
        [SetUp]
        public void Setup()
        {
            sut = new TourScheduleStub();
        }
        [Test]
        public void CanCreateBooking()
        {
            // Arrange
            // Act
            //Assert
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
