using HolidaySearch.Models;

namespace HolidaySearch;
public class Search
{

    public SearchResult FindBestValueHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration)
    {
        return new SearchResult()
        {
            Flight = new Flight()
            {
                Id = 2,
                Airline = "First Class Air",
                From = "MAN",
                To = "TFS",
                DepartureDate = new DateTime(2023,07,01)
            },
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

