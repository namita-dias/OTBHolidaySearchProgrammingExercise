using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public interface IHotelSearch
    {
        Hotel FindBestValueHotels(string travellingTo, DateTime arrivalDate, int duration);
    }
}