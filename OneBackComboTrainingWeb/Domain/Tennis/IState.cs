namespace OneBackComboTrainingWeb.Domain.Tennis;

public interface IState
{
    string Score();
    IState AddFirstPlayerScore();
    IState AddSecondPlayerScore();
}