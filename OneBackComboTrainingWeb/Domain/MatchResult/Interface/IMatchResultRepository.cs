namespace OneBackComboTrainingWeb.Domain.MatchResult.Interface;

public interface IMatchResultRepository
{
    string GetMatchResultById(int id);
    void SetMatchResult(int i, string hhh);
}