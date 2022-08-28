namespace SimpleMonopoly.Tests;

[TestFixture]
public class PropertyTileTest
{
    [SetUp]
    public void Setup()
    {
        _player = new Player("Player");
        _propertyTile = new PropertyTile("Test Property", 100, 1000);
        _board = new Board();
    }

    private Player _player;
    private PropertyTile _propertyTile;
    private Board _board;

    [Test]
    public void PropertyBuyTest()
    {
        _propertyTile.TileAction(_player, _board);

        Assert.Multiple(() =>
        {
            Assert.That(_propertyTile.Owner, Is.EqualTo(_player));
            Assert.That(_player.Properties.Any(property => property == _propertyTile));
        });
    }

    [TestCase(1900, 2100)]
    public void PayRentTest(int playerBalance, int ownerBalance)
    {
        var owner = new Player("Owner");
        _propertyTile.Owner = owner;
        _propertyTile.TileAction(_player, _board);

        Assert.Multiple(() =>
        {
            Assert.That(_player.Money, Is.EqualTo(playerBalance));
            Assert.That(owner.Money, Is.EqualTo(ownerBalance));
        });
    }
}