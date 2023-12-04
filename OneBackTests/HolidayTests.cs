namespace OneBackTests;

[TestFixture]
public class HolidayTests
{
    [Test]
    public void today_is_xmas()
    {
        var holiday = new HolidayForTest();
        holiday.Today = new DateTime(2000, 12, 25);
        Assert.That(holiday.GetTheme(), Is.EqualTo("Merry Xmas"));
    }
}

public class HolidayForTest : Holiday
{
    private DateTime _today;

    public DateTime Today
    {
        set => _today = value;
    }

    protected override DateTime GetToday()
    {
        return _today;
    }
}

public class Holiday
{
    public string GetTheme()
    {
        var today = GetToday();
        if (today.Month == 12 && today.Day == 25)
        {
            return "Merry Xmas";
        }

        return "Today is not Xmas";
    }

    protected virtual DateTime GetToday()
    {
        return DateTime.Today;
    }
}