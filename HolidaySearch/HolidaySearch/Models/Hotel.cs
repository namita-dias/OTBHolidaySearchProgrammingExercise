using System;
namespace HolidaySearch.Models
{
	public class Hotel
	{
        public int Id;
        public string Name = string.Empty;
        public DateTime ArrivalDate;
        public decimal PricePerNight = 0.0M;
        public string LocalAirport = string.Empty;
        public int Nights;
    }
}

