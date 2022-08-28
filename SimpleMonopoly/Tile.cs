namespace SimpleMonopoly;

public abstract class Tile
{
    public Tile(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public abstract void TileAction(Player player, Board board);

    public override string? ToString()
    {
        return Name;
    }
}