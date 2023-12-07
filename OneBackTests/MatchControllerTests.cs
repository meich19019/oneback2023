using NSubstitute;
using OneBackComboTrainingWeb.Domain.MatchResult;
using OneBackComboTrainingWeb.Domain.MatchResult.Interface;

namespace OneBackTests;

[TestFixture]
public class MatchControllerTests
{
    private const int Id = 91;
    private MatchController _matchController;
    private IMatchResultRepository _matchResultRepository;

    [SetUp]
    public void Setup()
    {
        _matchResultRepository = Substitute.For<IMatchResultRepository>();
        _matchController = new MatchController(_matchResultRepository);
    }

    [Test]
    public void no_event_0_0()
    {
        GivenMatchResult("");
        var matchResult = WhenEvent(EventType.NotExist);
        ResultShouldBe(matchResult, "0:0(First Half)");
    }

    [Test]
    public void no_event_1_0()
    {
        GivenMatchResult("H");
        var matchResult = WhenEvent(EventType.NotExist);
        ResultShouldBe(matchResult, "1:0(First Half)");
        
    }

    [Test]
    public void home_goal_0_0()
    {
        GivenMatchResult("");
        var matchResult = WhenEvent(EventType.HomeGoal);
        ResultShouldBe(matchResult, "1:0(First Half)");
    }

    [Test]
    public void home_goal_1_0()
    {
        GivenMatchResult("H");
        var matchResult = WhenEvent(EventType.HomeGoal);
        ResultShouldBe(matchResult, "2:0(First Half)");
    }

    [Test]
    public void home_goal_2_0()
    {
        GivenMatchResult("HH");
        var matchResult = WhenEvent(EventType.HomeGoal);
        ResultShouldBe(matchResult, "3:0(First Half)");
        ResultShouldBeChanged("HHH");
    }

    [Test]
    public void next_period_1_0()
    {
        GivenMatchResult("H");
        var matchResult = WhenEvent(EventType.NextPeriod);
        ResultShouldBe(matchResult, "1:0(Second Half)");
        ResultShouldBeChanged("H;");
    }

    [Test]
    public void home_cancel_2_0_first()
    {
        GivenMatchResult("HH");
        var matchResult = WhenEvent(EventType.HomeCancelGoal);
        ResultShouldBe(matchResult, "1:0(First Half)");
        ResultShouldBeChanged("H");
    }

    [Test]
    public void home_cancel_2_0_second()
    {
        GivenMatchResult("HH;");
        var matchResult = WhenEvent(EventType.HomeCancelGoal);
        ResultShouldBe(matchResult, "1:0(Second Half)");
        ResultShouldBeChanged("H;");
    }

    [Test]
    public void away_goal_0_0()
    {
        GivenMatchResult("");
        var matchResult = WhenEvent(EventType.AwayGoal);
        ResultShouldBe(matchResult, "0:1(First Half)");
        ResultShouldBeChanged("A");
    }

    [Test]
    public void away_goal_1_1()
    {
        GivenMatchResult("HA");
        var matchResult = WhenEvent(EventType.AwayGoal);
        ResultShouldBe(matchResult, "1:2(First Half)");
        ResultShouldBeChanged("HAA");
    }

    [Test]
    public void away_cancel_0_1_first()
    {
        GivenMatchResult("A");
        var matchResult = WhenEvent(EventType.AwayCancelGoal);
        ResultShouldBe(matchResult, "0:0(First Half)");
        ResultShouldBeChanged("");
    }

    [Test]
    public void away_cancel_0_2_second()
    {
        GivenMatchResult("AA;");
        var matchResult = WhenEvent(EventType.AwayCancelGoal);
        ResultShouldBe(matchResult, "0:1(Second Half)");
        ResultShouldBeChanged("A;");
    }

    [Test]
    public void away_cancel_1_0()
    {
        GivenMatchResult("H");
        Assert.Catch<InvalidOperationException>(() => WhenEvent(EventType.AwayCancelGoal));
    }

    private void ResultShouldBeChanged(string expected)
    {
        _matchResultRepository.Received(1).SetMatchResult(Id, expected);
    }

    private void GivenMatchResult(string result)
    {
        _matchResultRepository.GetMatchResultById(Arg.Any<int>()).Returns(result);
    }

    private string WhenEvent(EventType eventType)
    {
        return _matchController.UpdateMatchResult(Id, eventType);
    }

    private void ResultShouldBe(string matchResult, string expected)
    {
        Assert.AreEqual(expected, matchResult);
    }
}