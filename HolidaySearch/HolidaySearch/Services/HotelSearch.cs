using System;
using System.Text.Json;
using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public class HotelSearch : IHotelSearch
    {
        public HotelSearch()
        {
        }

        public Hotel FindBestValueHotels(string travellingTo, DateTime arrivalDate, int duration)
        {
            return new Hotel()
            {
                Id = 9,
                Name = "Nh Malaga",
                ArrivalDate = new DateTime(2023,07,05),
                PricePerNight = 83,
                LocalAirport = "AGP",
                Nights = 7
            };
        }
    }
}

