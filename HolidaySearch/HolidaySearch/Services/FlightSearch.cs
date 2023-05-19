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

        public List<Flight> FindBestValueFlight(List<string> departingFrom, string travellingTo, DateTime departureDate)
        {
            List<Flight> flights = ReadFlightsData();

            try
            {
                List<Flight> bestValueFlights = new List<Flight>();

                if (departingFrom.Contains("Any Airport"))
                    bestValueFlights = flights.Where(flight => flight.To.Contains(travellingTo) && flight.Departure_Date == departureDate).OrderBy(price => price.Price).ToList();
                else
                {
                    foreach(string airport in departingFrom)
                    {
                        bestValueFlights.Add(flights.Where(flight => flight.From.Contains(airport) && flight.To.Contains(travellingTo) && flight.Departure_Date == departureDate).FirstOrDefault());
                    }
                }

                return bestValueFlights;
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

