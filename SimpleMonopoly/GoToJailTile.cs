namespace SimpleMonopoly;

public class GoToJailTile : Tile
{
    public GoToJailTile(string name) : base(name)
    {
    }

    public override void TileAction(Player player, Board board)
    {
        Util.Print($"{player} is going to jail!");
        player.MoveToJail(board);
    }
}