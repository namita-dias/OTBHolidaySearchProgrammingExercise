using System.Linq;
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

    public List<SearchResult> FindBestValueHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration)
    {
        try
        { 

            List<Flight> bestValueFlights = flightSearch.FindBestValueFlight(departingFrom, travellingTo, departureDate);
            List<Hotel> bestValueHotels = hotelSearch.FindBestValueHotels(travellingTo, departureDate, duration);

            List<SearchResult> bestValueHolidays = CombineFlightsAndHotels(bestValueFlights, bestValueHotels);

            return bestValueHolidays.OrderBy(price => price.TotalPrice).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error finding the best value holiday." + ex);
            return null;
        }
    }

    private List<SearchResult> CombineFlightsAndHotels(List<Flight> bestValueFlights, List<Hotel> bestValueHotels)
    {
        List<SearchResult> searchResult = new List<SearchResult>();
        try
        {
            var leftOuterJoin = bestValueFlights
                                .GroupJoin(bestValueHotels,
                                flight => flight.Departure_Date,
                                hotel => hotel.Arrival_Date,
                                (flight, hotel) => new { flight, hotel })
                                .SelectMany(
                                    x => x.hotel.DefaultIfEmpty(),
                                    (flight, hotel) => new
                                    {
                                        flight.flight,
                                        hotel
                                    });

            var rightOuterJoin = bestValueHotels
                                .GroupJoin(bestValueFlights,
                                hotel => hotel.Arrival_Date,
                                flight => flight.Departure_Date,
                                (hotel, flight) => new { hotel, flight })
                                .SelectMany(
                                    x => x.flight.DefaultIfEmpty(),
                                    (hotel, flight) => new
                                    {
                                        flight,
                                        hotel.hotel
                                    });

            var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);

            foreach (var result in fullOuterJoin)
            {
                Flight flight = result.flight;
                Hotel hotel = result.hotel;
                decimal totalPrice = result.flight.Price + (result.hotel.Price_Per_Night * result.hotel.Nights);

                searchResult.Add(new SearchResult()
                {
                    Flight = flight,
                    Hotel = hotel,
                    TotalPrice = totalPrice
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error combining flights and hotels." + ex);
            return null;
        }
        return searchResult;
    }
}

