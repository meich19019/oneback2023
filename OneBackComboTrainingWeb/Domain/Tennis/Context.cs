namespace OneBackComboTrainingWeb.Domain.Tennis;

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