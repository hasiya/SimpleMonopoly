namespace SimpleMonopoly;

public class GoTile : Tile
{
    public GoTile(string name) : base(name)
    {
    }

    public override void TileAction(Player player, Board board)
    {
        player.AddMoney(200);
        board.PlayRounds++;
        Util.Print($"{player} is awarded £200 for passing/landing on Go!");
    }
}