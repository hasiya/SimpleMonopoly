using System;
namespace SimpleMonopoly
{
    public class GoToJailTile : Tile
    {

        public GoToJailTile(string name) : base(name)
        {
        }

        public override void TileAction(Player player, Board board)
        {
            Util.Print($"{player.Name} is going jail!");
            player.IsInJail = true;
            board.MovePlayerTo(Board.JAIL_POSITION);
        }
    }
}

