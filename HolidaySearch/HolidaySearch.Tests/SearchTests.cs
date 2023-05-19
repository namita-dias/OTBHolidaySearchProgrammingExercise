namespace HolidaySearch.Tests;

public class SearchTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Manchester Airport (MAN)", "Malaga Airport (AGP)", "2023/07/01", 7, 2, 9)]
    public void GivenAValidInput_ThenReturnsBestValueHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration, int expectedFlight, int expectedHotel)
    {
        Search search = new Search();

        var result = search.FindBestValueHoliday(departingFrom, travellingTo, departureDate, duration);

        Assert.That(expectedFlight, Is.EqualTo(result.Flight.Id));
        Assert.That(expectedHotel, Is.EqualTo(result.Hotel.Id));
    }
}
