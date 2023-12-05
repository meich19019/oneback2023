using OneBackComboTrainingWeb.Domain.Tennis;

namespace OneBackTests;

[TestFixture]
public class TennisGameTest
{
    private TennisGame _tennisGame;

    [SetUp]
    public void Setup()
    {
        _tennisGame = new TennisGame();
    }

    [Test]
    public void first_state()
    {
        ScoreShouldBe("love all");
    }

    [Test]
    public void all_to_lookup_fifteen()
    {
        _tennisGame.AddFirstPlayerScore();
        ScoreShouldBe("fifteen love");
    }

    [Test]
    public void lookup_to_all()
    {
        _tennisGame.AddFirstPlayerScore();
        _tennisGame.AddSecondPlayerScore();
        ScoreShouldBe("fifteen all");
    }

    [Test]
    public void all_to_lookup_thirty()
    {
        _tennisGame.AddFirstPlayerScore();
        _tennisGame.AddSecondPlayerScore();
        _tennisGame.AddFirstPlayerScore();
        ScoreShouldBe("thirty fifteen");
    }

    [Test]
    public void lookup_to_lookup_first_player()
    {
        _tennisGame.AddFirstPlayerScore();
        _tennisGame.AddFirstPlayerScore();
        ScoreShouldBe("thirty love");
    }

    [Test]
    public void lookup_to_lookup_second_player()
    {
        _tennisGame.AddSecondPlayerScore();
        _tennisGame.AddSecondPlayerScore();
        ScoreShouldBe("love thirty");
    }

    [Test]
    public void lookup_to_deuce()
    {
        _tennisGame.AddFirstPlayerScore();
        _tennisGame.AddFirstPlayerScore();
        _tennisGame.AddFirstPlayerScore();
        _tennisGame.AddSecondPlayerScore();
        _tennisGame.AddSecondPlayerScore();
        _tennisGame.AddSecondPlayerScore();
        ScoreShouldBe("deuce");
    }

    private void ScoreShouldBe(string loveAll)
    {
        var score = _tennisGame.Score();
        Assert.AreEqual(loveAll, score);
    }
}