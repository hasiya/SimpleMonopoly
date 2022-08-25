using System;
namespace SimpleMonopoly
{
    public abstract class Tile
    {

        public string Name { get; set; }
        public Tile(string name)
        {
            Name = name;
        }

        public abstract void TileAction(Player player, Board board);

        public override string? ToString()
        {
            return Name;
        }
    }
}

