using System.Text;
using Microsoft.AspNetCore.Mvc;
using OneBackComboTrainingWeb.Domain.MatchResult.Interface;

namespace OneBackComboTrainingWeb.Domain.MatchResult;

[ApiController]
[Route("[controller]")]
public class MatchController : ControllerBase
{
    private readonly IMatchResultRepository _matchResultRepository;

    public MatchController(IMatchResultRepository matchResultRepository)
    {
        _matchResultRepository = matchResultRepository;
    }

    public string UpdateMatchResult(int id, EventType eventType)
    {
        var result = _matchResultRepository.GetMatchResultById(id);

        var matchResultModel = new MatchResultModel(result);


        if (eventType == EventType.HomeGoal)
        {
            matchResultModel.AddHome();
        }
        else if (eventType == EventType.AwayGoal)
        {
            matchResultModel.AddAway();
        }
        else if (eventType == EventType.NextPeriod)
        {
            matchResultModel.NextPeriod();
        }
        else if (eventType == EventType.HomeCancelGoal)
        {
            matchResultModel.ReduceHome();
        }
        else if (eventType == EventType.AwayCancelGoal)
        {
            matchResultModel.ReduceAway();

        }

        _matchResultRepository.SetMatchResult(id, matchResultModel.GetResult());


        return matchResultModel.GetScore();
    }
}

internal class MatchResultModel
{
    private string _matchResult;

    public MatchResultModel(string matchResult)
    {
        _matchResult = matchResult;
    }

    public string GetScore()
    {
        var matchResultMapping = _matchResult.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var homeScore = matchResultMapping.GetValueOrDefault('H');
        var awayScore = matchResultMapping.GetValueOrDefault('A');
        var nextPeriod = matchResultMapping.GetValueOrDefault(';') == 0 ? "First Half" : "Second Half";
        return $"{homeScore}:{awayScore}({nextPeriod})";
    }

    public void AddHome()
    {
        _matchResult += "H";
    }

    public void NextPeriod()
    {
        _matchResult += ";";
    }

    public string GetResult()
    {
        return _matchResult;
    }

    public void Reduce(char target)
    {
        var lastHomeAwayIndex = _matchResult.LastIndexOfAny(new[] { 'H', 'A' });

        if (lastHomeAwayIndex < 0)
        {
            return;
        }

        if (_matchResult[lastHomeAwayIndex] == target)
        {
            _matchResult = _matchResult.Remove(lastHomeAwayIndex, 1);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void AddAway()
    {
        _matchResult += "A";
    }

    public void ReduceHome()
    {
        Reduce('H');
    }

    public void ReduceAway()
    {
        Reduce('A');
    }
}