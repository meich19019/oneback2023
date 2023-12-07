namespace OneBackComboTrainingWeb.Domain.Tennis;

public class TennisGame
{
    private IState _currentState;
    //private IState _currentState;
    private readonly Context _context;

    public TennisGame(string firstPlayerName, string secondPlayerName)
    {
        _context = new Context(firstPlayerName, secondPlayerName);
        _currentState = new AllState(_context);
    }

    public string Score()
    {
        return _currentState.Score();
    }

    public void AddFirstPlayerScore()
    {
        _context.FirstPlayerScore++;
        _currentState = _currentState.NextState();
    }

    public void AddSecondPlayerScore()
    {
        _context.SecondPlayerScore++;
        _currentState = _currentState.NextState();
    }
}