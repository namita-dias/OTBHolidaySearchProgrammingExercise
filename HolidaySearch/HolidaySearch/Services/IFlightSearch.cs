using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public interface IFlightSearch
    {
        List<Flight> FindBestValueFlight(List<string> departingFrom, string travellingTo, DateTime departureDate);
    }
}