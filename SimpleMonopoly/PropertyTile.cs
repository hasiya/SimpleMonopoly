using System;
namespace SimpleMonopoly
{
    public class PropertyTile : Tile
    {
        public int Rent { get; set; }
        public int Cost { get; set; }


        public PropertyTile(string name, int rent, int cost) : base(name)
        {
            Cost = cost;
            Rent = rent;
        }

        public override void TileAction(Player player, Board board)
        {
            throw new NotImplementedException();
        }

        public override string? ToString()
        {
            return $"{Name} - Rent: {Rent}, Cost: {Cost}";
        }
    }
}

