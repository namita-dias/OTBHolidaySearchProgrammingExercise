using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public interface IFlightSearch
    {
        Flight FindBestValueFlight(string departingFrom, string travellingTo, DateTime departureDate, int duration);
    }
}