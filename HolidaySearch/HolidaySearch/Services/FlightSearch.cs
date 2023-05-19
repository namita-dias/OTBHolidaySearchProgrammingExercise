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

        public Flight FindBestValueFlight(string departingFrom, string travellingTo, DateTime departureDate)
        {
            List<Flight> test = ReadFlightsData();

            return ReadFlightsData().Where(flight => flight.From == (departingFrom.Split('(', ')')[1]) && flight.To == (travellingTo.Split('(', ')')[1]) && flight.Departure_Date == departureDate).FirstOrDefault();
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

