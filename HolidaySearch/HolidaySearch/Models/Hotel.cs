using System;
namespace HolidaySearch.Models
{
	public class Hotel
	{
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Arrival_Date { get; set; }
        public decimal Price_Per_Night { get; set; } = 0.0M;
        public List<string> Local_Airports { get; set; } = new List<string>();
        public int Nights { get; set; }
    }
}

