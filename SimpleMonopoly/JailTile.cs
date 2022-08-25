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
            throw new NotImplementedException();
        }
    }
}

