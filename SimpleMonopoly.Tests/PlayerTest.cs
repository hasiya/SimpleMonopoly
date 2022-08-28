namespace SimpleMonopoly.Tests;

[TestFixture]
public class PlayerTest
{
    [SetUp]
    public void Setup()
    {
        _player = new Player("Player");
        _board = new Board
        {
            CurrentPlayer = _player
        };
    }

    private Player _player;
    private Board _board;

    [TestCase(200, 2200)]
    [TestCase(750, 2750)]
    [TestCase(1590, 3590)]
    public void PlayerAddMoneyTest(int value, int expectedValue)
    {
        _player.AddMoney(value);
        Assert.That(_player.Money, Is.EqualTo(expectedValue));
    }

    [TestCase(500, 1500)]
    [TestCase(2500, -500)]
    [TestCase(1800, 200)]
    public void PlayerSubtractMoneyTest(int value, int expectedValue)
    {
        _player.SubtractMoney(value);
        Assert.That(_player.Money, Is.EqualTo(expectedValue));
    }

    [TestCase(500, 1500, 2500)]
    [TestCase(1500, 500, 3500)]
    [TestCase(2900, -900, 4900)]
    public void PlayerPayingAnotherPlayerTest(int value, int expectedPlayerBalance, int expectedOtherPlayerBalance)
    {
        var otherPlayer = new Player("Other");

        _player.PayAnotherPlayer(otherPlayer, value);
        Assert.Multiple(() =>
        {
            Assert.That(_player.Money, Is.EqualTo(expectedPlayerBalance));
            Assert.That(otherPlayer.Money, Is.EqualTo(expectedOtherPlayerBalance));
        });
    }

    [Test]
    public void PlayerInJailTest()
    {
        _player.MoveToJail(_board);

        Assert.Multiple(() =>
        {
            Assert.That(_player.IsInJail, Is.EqualTo(true));
            Assert.That(_player.Position, Is.EqualTo(Board.JailPosition));
        });
    }
}