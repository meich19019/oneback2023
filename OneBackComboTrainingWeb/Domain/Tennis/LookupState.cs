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

    public override IState AddFirstPlayerScore()
    {
        return GetState();
    }

    public override IState AddSecondPlayerScore()
    {
        return GetState();
    }

    private IState GetState()
    {
        if (Context.FirstPlayerScore == Context.SecondPlayerScore)
        {
            if (Context.FirstPlayerScore >= 3)
            {
                return new DeuceState(Context);
            }

            return new AllState(Context);
        }
        return new LookupState(Context);
    }
}