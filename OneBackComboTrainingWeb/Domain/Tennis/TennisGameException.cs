namespace OneBackComboTrainingWeb.Domain.Tennis;

public class TennisGameException : Exception
{
    public TennisGameException()
    {
    }

    public TennisGameException(string? message) : base(message)
    {
    }

    public TennisGameException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}