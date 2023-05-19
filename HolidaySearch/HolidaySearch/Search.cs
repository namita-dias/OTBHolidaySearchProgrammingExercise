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
        try { 

            Flight bestValueFlight = flightSearch.FindBestValueFlight(departingFrom, travellingTo, departureDate);
            Hotel bestValueHotel = hotelSearch.FindBestValueHotels(travellingTo, departureDate, duration);

            return new SearchResult()
            {
                Flight = bestValueFlight,
                Hotel = bestValueHotel,
                TotalPrice = (bestValueFlight.Price + (bestValueHotel.Price_Per_Night * duration)).ToString("C")
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error finding the best value holiday." + ex);
            return null;
        }
    }
}

