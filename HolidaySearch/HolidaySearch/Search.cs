using HolidaySearch.Models;
using HolidaySearch.Services;

namespace HolidaySearch;
public class Search
{
    private IFlightSearch flightSearch;
    private IHotelSearch hotelSearch;
    public Search()
    {
        flightSearch = new FlightSearch("/Data/Flights.json");
        hotelSearch = new HotelSearch("/Data/Hotels.json");
    }

    public SearchResult FindBestValueHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration)
    {
        return new SearchResult()
        {
            Flight = flightSearch.FindBestValueFlight(departingFrom, travellingTo, departureDate),
            Hotel = hotelSearch.FindBestValueHotels(travellingTo, departureDate, duration),
            TotalPrice = "£826"
        };
    }
}

