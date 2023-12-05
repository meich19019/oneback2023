namespace OneBackComboTrainingWeb.Domain.Tennis;

public abstract class StateBase : IState
{
    protected Context Context;
    protected Dictionary<int, string> ScoreLookup = new()
    {
        {0, "love"},
        {1, "fifteen"},
        {2, "thirty"},
        {3, "forty"}
    };

    protected StateBase(Context context)
    {
        Context = context;
    }
    public abstract string Score();

    public abstract IState AddFirstPlayerScore();

    public abstract IState AddSecondPlayerScore();
}