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

    [Test]
    public void lookup_to_all()
    {
        _tennisGame.AddFirstPlayerScore();
        _tennisGame.AddSecondPlayerScore();
        ScoreShouldBe("fifteen all");
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
    private Context _context;

    public TennisGame()
    {
        _context = new Context();
        _currentState = new AllState(_context);
    }

    public string Score()
    {
        return _currentState.Score();
    }

    public void AddFirstPlayerScore()
    {
        _context.FirstPlayerScore++;
        _currentState = _currentState.AddFirstPlayerScore();
    }

    public void AddSecondPlayerScore()
    {
        _context.SecondPlayerScore++;
        _currentState = _currentState.AddSecondPlayerScore();
    }
}

public interface IState
{
    string Score();
    IState AddFirstPlayerScore();
    IState AddSecondPlayerScore();
}

public abstract class StateBase : IState
{
    protected Context _context;
    protected Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
    {
        {0, "love"},
        {1, "fifteen"},
        {2, "thirty"},
        {3, "forty"}
    };

    public StateBase(Context context)
    {
        _context = context;
    }
    public abstract string Score();

    public abstract IState AddFirstPlayerScore();

    public abstract IState AddSecondPlayerScore();
}

public class Context
{
    public Context()
    {
        FirstPlayerScore = 0;
        SecondPlayerScore = 0;
    }

    public int FirstPlayerScore { get; set; }
    public int SecondPlayerScore { get; set; }
}

public class AllState : StateBase
{


    public override string Score()
    {
        return $"{_scoreLookup[_context.FirstPlayerScore]} all";
    }

    public override IState AddFirstPlayerScore()
    {
        return new LookupState(_context);
    }

    public override IState AddSecondPlayerScore()
    {
        return new LookupState(_context);
    }

    public AllState(Context context) : base(context)
    {
    }
}

public class LookupState : StateBase
{
    public override string Score()
    {
        return $"{_scoreLookup[_context.FirstPlayerScore]} {_scoreLookup[_context.SecondPlayerScore]}";
    }

    public override IState AddFirstPlayerScore()
    {
        return new AllState(_context);
    }

    public override IState AddSecondPlayerScore()
    {
        return new AllState(_context);
    }

    public LookupState(Context context) : base(context)
    {
    }
}