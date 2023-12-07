namespace OneBackComboTrainingWeb.Domain.Tennis;

public class DeuceState : StateBase
{
    public DeuceState(Context context) : base(context)
    {
    }

    public override string Score()
    {
        return "deuce";
    }

    public override IState NextState()
    {
        return new AdvState(Context);
    }
}