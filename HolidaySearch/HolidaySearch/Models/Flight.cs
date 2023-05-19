﻿using System;
namespace HolidaySearch.Models
{
	public class Flight
	{
        public int Id { get; set; }
        public string Airline { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0.0M;
        public DateTime Departure_Date { get; set; }
    }
}

