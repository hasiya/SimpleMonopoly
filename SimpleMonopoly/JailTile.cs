using System;
namespace SimpleMonopoly
{
    public class JailTile : Tile
    {
        public JailTile(string name) : base(name)
        {
        }

        public override void TileAction(Player player, Board board)
        {
            if (player.IsInJail)
            {
                Util.Print($"{player.Name} is in Jail");
            }
            else
            {
                Util.Print($"{player.Name} is visiting Jail");
            }
        }
    }
}

