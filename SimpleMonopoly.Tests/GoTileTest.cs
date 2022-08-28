namespace SimpleMonopoly.Tests;

[TestFixture]
public class GoTileTest
{
    [SetUp]
    public void Setup()
    {
        _player = new Player("Player");
        _goTile = new GoTile("Go");
        _board = new Board();
    }

    private Player _player;
    private GoTile _goTile;
    private Board _board;

    [TestCase(2200)]
    public void GoActionTest(int expectedResult)
    {
        _goTile.TileAction(_player, _board);
        Assert.That(_player.Money, Is.EqualTo(expectedResult));
    }
}