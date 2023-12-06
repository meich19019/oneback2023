﻿namespace OneBackComboTrainingWeb.Domain.Tennis;

public class DeuceState : StateBase
{
    public DeuceState(Context context) : base(context)
    {
    }

    public override string Score()
    {
        return "deuce";
    }

    public override IState AddFirstPlayerScore()
    {
        return new AdvState(Context);
    }

    public override IState AddSecondPlayerScore()
    {
        return new AdvState(Context);
    }
}