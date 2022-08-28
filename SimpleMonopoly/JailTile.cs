namespace SimpleMonopoly;

public class JailTile : Tile
{
    public JailTile(string name) : base(name)
    {
    }

    public override void TileAction(Player player, Board board)
    {
        if (player.IsInJail && player.JustMovedToJail)
        {
            Util.Print($"{player} is in jail.");
            player.JustMovedToJail = false;
        }
        else if (player.IsInJail)
        {
            var diceValue = Player.RollDie();
            Util.Print($"From jail {player} rolled a {diceValue}.");
            if (diceValue >= 3)
            {
                Util.Print($"{player} has been released from jail!");
                player.IsInJail = false;
            }
            else
            {
                Util.Print($"{player} is stuck in jail!");
            }
        }
        else
        {
            Util.Print($"{player} is visiting jail.");
        }
    }
}