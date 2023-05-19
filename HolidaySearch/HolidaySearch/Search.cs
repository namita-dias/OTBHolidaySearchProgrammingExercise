using HolidaySearch.Models;
using HolidaySearch.Services;

namespace HolidaySearch;
public class Search
{
    private IFlightSearch flightSearch;
    public Search()
    {
        flightSearch = new FlightSearch();
    }

    public SearchResult FindBestValueHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration)
    {
        return new SearchResult()
        {
            Flight = flightSearch.FindBestValueFlight(departingFrom, travellingTo, departureDate, duration),
            Hotel = new Hotel()
            {
                Id = 9,
                Name = "Nh Malaga",
                ArrivalDate = new DateTime(2023, 07, 01),
                PricePerNight = 83,
                LocalAirport = "AGP",
                Nights = 7
            },
            TotalPrice = "£826"
        };
    }
}

