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
    [TestCase("Any Airport", "Gran Canaria Airport (LPA)", "2022/11/10", 14, 7, 6)]
    public void GivenAValidInput_ThenReturnsBestValueHoliday(string departingFrom, string travellingTo, DateTime departureDate, int duration, int expectedFlight, int expectedHotel)
    {
        var result = search.FindBestValueHoliday(departingFrom, travellingTo, departureDate, duration);

        Assert.That(result.First().Flight.Id, Is.EqualTo(expectedFlight));
        Assert.That(result.First().Hotel.Id, Is.EqualTo(expectedHotel));
    }

    [TestCase("No Airport", "Gran Canaria Airport (LPA)", "2022/11/10", 14)]
    [TestCase("London Luton Airport (LTN)", "No Airport", "2022/11/10", 14)]
    [TestCase("London Luton Airport (LTN)", "Gran Canaria Airport (LPA)", "0001/01/01", 14)]
    [TestCase("London Luton Airport (LTN)", "Gran Canaria Airport (LPA)", "2022/11/10", 0)]
    public void GivenInvalidInput_ThenReturnsNull(string departingFrom, string travellingTo, DateTime departureDate, int duration)
    {
        var result = search.FindBestValueHoliday(departingFrom, travellingTo, departureDate, duration);

        Assert.IsNull(result);
    }
}
