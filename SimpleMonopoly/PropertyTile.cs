namespace SimpleMonopoly;

/// <summary>
/// <c>PropertyTile</c> class represents all the different "Property" tile in the Monopoly Board.
/// <c>PropertyTile</c> class is a child class of <c>Tile</c> class. 
/// The <c>PropertyTile</c> contains following Properties to create the <c>PropertyTile</c> object.
/// <c>Rent</c> Property to store the rent value of this property.
/// <c>Cost</c> Property to store the cost of this property.
/// <c>Owner</c> property to store the owner(<c>Player</c> object) of this property. 
/// </summary>
public class PropertyTile : Tile
{
    public int Rent { get; }
    public int Cost { get; set; }
    public Player? Owner { get; set; }


    /// <summary>
    /// Constructor of the <c>PropertyTile</c> class.
    /// </summary>
    /// <param name="name">A string parameter to initialise the <c>Name</c> Property that derived from the <c>Tile</c>
    /// parent class.</param>
    /// <param name="rent">An Integer parameter to initialise the <c>Rent</c> Property.</param>
    /// <param name="cost">An Integer parameter to Initialise the <c>Cost</c> Property.</param>
    public PropertyTile(string name, int rent, int cost) : base(name)
    {
        Cost = cost;
        Rent = rent;
        Owner = null;
    }

    /// <summary>
    /// The <c>TileAction</c> override method executes the <c>PropertyTile</c> action.
    /// When the <c>CurrentPlayer</c> lands on a <c>PropertyTile</c> tile the method check if there is an owner for this
    /// property. If there is no owner and the <c>CurrentPlayer</c> has enough funds to buy this property, the <c>CurrentPlayer</c>
    /// will buy this property and becomes the owner of this property, if the <c>CurrentPlayer</c> doesn't have funds to
    /// buy the property the console outputs that <c>CurrentPlayer</c> doesn't have enough funds to buy the property.
    /// When the <c>CurrentPlayer</c> lands on the <c>PropertyTile</c> tile and if the <c>CurrentPlayer</c> owns the property,
    /// the console will print that the <c>CurrentPlayer</c> is visiting their property. If any of the other players owns
    /// that property, the <c>CurrentPlayer</c> have to pay the rent to the <c>Owner</c> of the property.
    /// </summary>
    /// <param name="player">The <c>Player</c> parameter object to call <c>CurrentPlayer</c> methods.</param>
    /// <param name="board">The <c>Board</c> parameter object to access the Monopoly board.</param>
    public override void TileAction(Player player, Board board)
    {
        if (Owner == null)
        {
            if (player.Money >= Cost)
            {
                // BuyProperty(player);
                player.SubtractMoney(Cost);
                Owner = player;
                player.Properties.Add(this);
                Util.Print($"{player} has purchased {this} for £{Cost}.");
            }
            else
            {
                Util.Print($"{player} does not have the funds for {this}.");
            }
        }
        else if (Owner == player)
        {
            Util.Print($"{player} is visiting their own property, {this}.");
        }
        else
        {
            // PayRent(player);
            player.PayAnotherPlayer(Owner, Rent);
            Util.Print($"{player} pays {Owner} £{Rent} for staying at {this}.");
        }
    }
}