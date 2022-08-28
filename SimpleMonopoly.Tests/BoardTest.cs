namespace SimpleMonopoly.Tests;

[TestFixture]
public class BoardTest
{
    [SetUp]
    public void Setup()
    {
        _player1 = new Player("Player1");
        _player2 = new Player("Player2");
        _board = new Board
        {
            CurrentPlayer = _player1,
            Players = new[]
            {
                _player1,
                _player2
            }
        };
    }

    private Player _player1;
    private Player _player2;
    private Board _board;

    [TestCase(0, 3, 3)]
    [TestCase(4, 5, 9)]
    [TestCase(11, 3, 2)]
    public void MovePlayerTest(int playerCurrentPosition, int numberOfTiles, int expectedResult)
    {
        _player1.Position = playerCurrentPosition;
        _board.MovePlayer(numberOfTiles);
        Assert.That(_player1.Position, Is.EqualTo(expectedResult));
    }

    [Test]
    public void NextTurnTest()
    {
        _board.NextTurn();
        Assert.That(_player2, Is.EqualTo(_board.CurrentPlayer));

        _board.NextTurn();
        Assert.That(_player1, Is.EqualTo(_board.CurrentPlayer));
    }
}