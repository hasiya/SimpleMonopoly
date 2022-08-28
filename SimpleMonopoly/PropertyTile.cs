namespace SimpleMonopoly;

public class PropertyTile : Tile
{
    public PropertyTile(string name, int rent, int cost) : base(name)
    {
        Cost = cost;
        Rent = rent;
        Owner = null;
    }

    public int Rent { get; }
    public int Cost { get; set; }
    public Player? Owner { get; set; }

    public override void TileAction(Player player, Board board)
    {
        if (Owner == null)
        {
            if (player.Money >= Cost)
            {
                BuyProperty(player);
                Util.Print($"{player} has purchased {this} for £{Cost}.");
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
            PayRent(player);
            Util.Print($"{player} pays {Owner} £{Rent} for staying at {this}.");
        }
    }

    public void BuyProperty(Player player)
    {
        player.SubtractMoney(Cost);
        Owner = player;
        player.Properties.Add(this);
    }

    public void PayRent(Player player)
    {
        if (Owner != null)
            player.PayAnotherPlayer(Owner, Rent);
    }

    public override string ToString()
    {
        return $"{Name} - {Rent} - {Cost}";
    }
}