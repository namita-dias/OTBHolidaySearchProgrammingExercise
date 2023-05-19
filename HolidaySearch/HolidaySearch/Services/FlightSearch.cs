using System;
using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public class FlightSearch : IFlightSearch
    {
        public FlightSearch()
        {
        }

        public Flight FindBestValueFlight(string departingFrom, string travellingTo, DateTime departureDate, int duration)
        {
            return new Flight()
            {
                Id = 2,
                Airline = "First Class Air",
                From = "MAN",
                To = "TFS",
                DepartureDate = new DateTime(2023, 07, 01)
            };
        }

    }
}

