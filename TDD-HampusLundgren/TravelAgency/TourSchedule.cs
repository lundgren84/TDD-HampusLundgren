using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule
    {
        public List<Tour> Tours { get; set; } = new List<Tour>();
        public void CreateTour(string name, DateTime date, int seats)
        {
            var slimedDate = new DateTime(date.Year, date.Month, date.Day);
            var toursOnSameDate = Tours.Where(x => x.Date == slimedDate).ToList();

            if (toursOnSameDate.Count >= 2)
            {
                throw new TourAllocationException();
            }
            else
            {
                Tours.Add(new Tour(name, slimedDate, seats));
            }
     
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            var toursForThatDate = Tours.Where(x => x.Date == dateTime).ToList();
            return toursForThatDate;
        }
    }
}
