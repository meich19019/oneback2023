namespace OneBackComboTrainingWeb.Domain.Tennis;

public class Context
{
    public Context(string firstPlayerName, string secondPlayerName)
    {
        FirstPlayerName = firstPlayerName;
        SecondPlayerName = secondPlayerName;
        FirstPlayerScore = 0;
        SecondPlayerScore = 0;
    }

    public int FirstPlayerScore { get; set; }
    public int SecondPlayerScore { get; set; }
    public string FirstPlayerName { get; set; }
    public string SecondPlayerName { get; set; }

    public string GetAdvPlayer()
    {
        return FirstPlayerScore > SecondPlayerScore ? FirstPlayerName : SecondPlayerName;
    }
}