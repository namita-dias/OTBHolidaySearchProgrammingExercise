using System;
namespace HolidaySearch.Models
{
	public class Flight
	{
        public int Id;
        public string Airline = string.Empty;
        public string From = string.Empty;
        public string To = string.Empty;
        public decimal Price = 0.0M;
        public DateTime DepartureDate;
    }
}

