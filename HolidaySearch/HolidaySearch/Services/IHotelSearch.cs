using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public interface IHotelSearch
    {
        List<Hotel> FindBestValueHotels(string travellingTo, DateTime arrivalDate, int duration);
    }
}