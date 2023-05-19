using System;
using HolidaySearch.Models;

namespace HolidaySearch.Helper
{
	 public static class AirportHelper
        {
            public static List<Airport> airports;

            public static List<Airport> AirportList()
            {
                return new List<Airport>
            {
                new Airport()
                {
                    AirportCode = "MAN",
                    AirportName = "Manchester Airport (MAN)"
                },
                new Airport()
                {
                    AirportCode = "TFS",
                    AirportName = "Tenerife South Airport (TFS)"
                },
                new Airport()
                {
                    AirportCode = "AGP",
                    AirportName = "Malaga Airport (AGP)"
                },
                new Airport()
                {
                    AirportCode = "PMI",
                    AirportName = "Mallorca Airport (PMI)"
                },
                new Airport()
                {
                    AirportCode = "LTN",
                    AirportName = "London Luton Airport (LTN)",
                    isLondon = true
                },
                new Airport()
                {
                    AirportCode = "LGW",
                    AirportName = "London Gatwick Airport (LGW)",
                    isLondon = true
                },
                new Airport()
                {
                    AirportCode = "LPA",
                    AirportName = "Gran Canaria Airport (LPA)"
                },
             };
            }

            public static List<string> GetAirportCodes(string fullAirportName)
            {
                List<string> airportCodes = new List<string>();
                try
                {
                    airports = AirportList();


                    if (fullAirportName == "Any Airport")
                        airportCodes.Add("Any Airport");
                    else
                        if (fullAirportName == "Any London Airport")
                        airportCodes = airports.Where(airport => airport.isLondon! == true).Select(code => code.AirportCode).ToList();
                    else
                        airportCodes = airports.Where(airport => airport.AirportName == fullAirportName).Select(code => code.AirportCode).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting airport codes." + ex);
                }

                return airportCodes;
            }
        }
}

