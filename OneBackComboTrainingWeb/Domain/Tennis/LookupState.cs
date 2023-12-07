namespace OneBackComboTrainingWeb.Domain.Tennis;

public class LookupState : StateBase
{
    public LookupState(Context context) : base(context)
    {
    }

    public override string Score()
    {
        return $"{ScoreLookup[Context.FirstPlayerScore]} {ScoreLookup[Context.SecondPlayerScore]}";
    }

    public override IState NextState()
    {
        if (Context.FirstPlayerScore == Context.SecondPlayerScore)
        {
            if (Context.FirstPlayerScore >= 3)
            {
                return new DeuceState(Context);
            }

            return new AllState(Context);
        }
        if (Context.FirstPlayerScore == 4 || Context.SecondPlayerScore == 4)
        {
            return new WinState(Context);
        }
        return this;
    }
}