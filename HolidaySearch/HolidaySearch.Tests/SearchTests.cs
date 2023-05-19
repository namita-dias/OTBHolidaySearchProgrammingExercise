namespace HolidaySearch.Tests;

public class SearchTests
{
    private Search search;
    [SetUp]
    public void Setup()
    {
        search = new Search();
    }

    [TestCase("Manchester Airport (MAN)", "Malaga Airport (AGP)", "2023/07/01", 7, 2, 9)]
    [TestCase("Any London Airport", "Mallorca Airport (PMI)", "2023/06/15", 10, 6, 5)]
    public void GivenAValidInput_ThenReturnsBestValueHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration, int expectedFlight, int expectedHotel)
    {
        var result = search.FindBestValueHoliday(departingFrom, travellingTo, departureDate, duration);

        Assert.That(result.Flight.Id, Is.EqualTo(expectedFlight));
        Assert.That(result.Hotel.Id, Is.EqualTo(expectedHotel));
    }
}
