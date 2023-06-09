﻿using System;
using System.Text.Json;
using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public class HotelSearch : IHotelSearch
    {
        private string _filePath;
        public HotelSearch(string filePath)
        {
            _filePath = Environment.CurrentDirectory + filePath;
        }

        public List<Hotel> FindBestValueHotels(string travellingTo, DateTime arrivalDate, int duration)
        {
            try
            {
                return ReadHotelData()!.Where(hotel => hotel.Local_Airports.Contains(travellingTo) && hotel.Arrival_Date == arrivalDate && hotel.Nights == duration).OrderBy(price => price.Price_Per_Night).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error finding best value hotel." + ex);
                return null;
            }
        }

        public List<Hotel> ReadHotelData()
        {
            try
            {
                string hotelJson = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Hotel>>(hotelJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading hotel data." + ex);
                return null;
            }
        }
    }
}

