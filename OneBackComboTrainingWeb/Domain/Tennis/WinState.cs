namespace OneBackComboTrainingWeb.Domain.Tennis;

public class WinState : StateBase
{
    public WinState(Context context) : base(context)
    {
    }

    public override string Score()
    {
        var advPlayer = Context.GetAdvPlayer();
        return $"{advPlayer} win";
    }

    public override IState NextState()
    {
        throw new TennisGameException();
    }
}