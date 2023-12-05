namespace OneBackComboTrainingWeb.Domain.Tennis;

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