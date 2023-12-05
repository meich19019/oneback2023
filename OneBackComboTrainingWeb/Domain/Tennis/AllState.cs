namespace OneBackComboTrainingWeb.Domain.Tennis;

public class AllState : StateBase
{
    public AllState(Context context) : base(context)
    {
    }


    public override string Score()
    {
        return $"{ScoreLookup[Context.FirstPlayerScore]} all";
    }

    public override IState AddFirstPlayerScore()
    {
        return new LookupState(Context);
    }

    public override IState AddSecondPlayerScore()
    {
        return new LookupState(Context);
    }
}