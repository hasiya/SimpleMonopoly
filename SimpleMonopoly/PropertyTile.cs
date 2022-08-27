using System;
namespace SimpleMonopoly
{
    public class PropertyTile : Tile
    {
        public int Rent { get; set; }
        public int Cost { get; set; }
        public Player? Owner { get; set; }


        public PropertyTile(string name, int rent, int cost) : base(name)
        {
            Cost = cost;
            Rent = rent;
            Owner = null;
        }

        public override void TileAction(Player player, Board board)
        {
            if (Owner == null)
            {
                if (player.Money >= Cost)
                {
                    player.SubtractMoney(Cost);
                    Owner = player;
                    player.Properties.Add(this);
                    Util.Print($"{player} has purchesed {this} for £{Cost}.");
                }
                else
                {
                    Util.Print($"{player} does not have the funds for {this}.");
                }
            }
            else if (Owner == player)
            {
                Util.Print($"{player} is visiting their own property {this}.");
            }
            else
            {
                player.SubtractMoney(Rent);
                Owner.AddMoney(Rent);
                Util.Print($"{player} pays {Owner} £{Rent} for staying at {this}.");
            }

        }
    }
}

