using System;
using System.Text.Json;
using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public class FlightSearch : IFlightSearch
    {
        private string _filePath;
        public FlightSearch(string filePath)
        {
            _filePath = Environment.CurrentDirectory + filePath;
        }

        public List<Flight> FindBestValueFlight(string departingFrom, string travellingTo, DateTime departureDate)
        {
            try
            {
                if (departingFrom.Contains("Any London Airport"))
                    return ReadFlightsData().Where(flight => (flight.From == "LTN" || flight.From == "LGW") && flight.To == (travellingTo.Split('(', ')')[1]) && flight.Departure_Date == departureDate).OrderBy(price => price.Price).ToList();
                else
                    if (departingFrom.Contains("Any Airport"))
                    return ReadFlightsData().Where(flight => flight.To == (travellingTo.Split('(', ')')[1]) && flight.Departure_Date == departureDate).OrderBy(price => price.Price).ToList();
                else
                    return ReadFlightsData().Where(flight => flight.From == (departingFrom.Split('(', ')')[1]) && flight.To == (travellingTo.Split('(', ')')[1]) && flight.Departure_Date == departureDate).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error finding best value flights." + ex);
                return null;
            }
        }

        private List<Flight> ReadFlightsData()
        {
            try
            {
                string flightJson = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Flight>>(flightJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading flight data." + ex);
                return null;
            }
        }

    }
}

