namespace OneBackComboTrainingWeb.Domain.Tennis;

public class WinState : StateBase
{
    public WinState(Context context) : base(context)
    {
    }

    public override string Score()
    {
        var advPlayer = GetAdvPlayer();
        return $"{advPlayer} win";
    }

    public override IState AddFirstPlayerScore()
    {
        throw new NotImplementedException();
    }

    public override IState AddSecondPlayerScore()
    {
        throw new NotImplementedException();
    }
}