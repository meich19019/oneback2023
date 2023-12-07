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

    public override IState NextState()
    {
        return new LookupState(Context);
    }
}