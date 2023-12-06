namespace OneBackComboTrainingWeb.Domain.Tennis;

public class AdvState : StateBase
{
    public AdvState(Context context) : base(context)
    {

    }

    public override string Score()
    {
        var advPlayer = GetAdvPlayer();
        return $"{advPlayer} adv";
    }


    public override IState AddFirstPlayerScore()
    {
        return new WinState(Context);
    }

    public override IState AddSecondPlayerScore()
    {
        return new WinState(Context);
    }
}