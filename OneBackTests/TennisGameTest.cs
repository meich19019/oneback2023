namespace OneBackTests;

[TestFixture]
public class TennisGameTest
{
    private TennisGame _tennisGame;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new TennisGame();
    }

    [Test]
    public void first_state()
    {
        ScoreShouldBe("love all");
    }

    [Test]
    public void all_to_lookup()
    {
        _tennisGame.AddFirstPlayerScore();   
        ScoreShouldBe("fifteen love");
    }

    private void ScoreShouldBe(string loveAll)
    {
        var score = _tennisGame.Score();
        Assert.AreEqual(loveAll, score);
    }
}

public class TennisGame
{
    private IState _currentState;

    public TennisGame()
    {
        _currentState =new AllState();
    }

    public string Score()
    {
        return _currentState.Score();
    }

    public void AddFirstPlayerScore()
    {
        _currentState = _currentState.AddFirstPlayerScore();
    }
}

public interface IState
{
    string Score();
    IState AddFirstPlayerScore();
}

public class AllState : IState
{
    public string Score()
    {
        return "love all";
    }

    public IState AddFirstPlayerScore()
    {
        return new LookupState();
    }
}

public class LookupState : IState
{
    public string Score()
    {
        return "fifteen love";
    }

    public IState AddFirstPlayerScore()
    {
        throw new NotImplementedException();
    }
}