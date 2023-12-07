namespace OneBackComboTrainingWeb.Domain.Tennis;

public class AdvState : StateBase
{
    public AdvState(Context context) : base(context)
    {

    }

    public override string Score()
    {
        var advPlayer = Context.GetAdvPlayer();
        return $"{advPlayer} adv";
    }


    public override IState NextState()
    {
        return new WinState(Context);
    }
}