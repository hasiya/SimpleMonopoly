namespace SimpleMonopoly;

/// <summary>
/// <c>ChanceTile</c> class represents the "Chance" tile in the Monopoly Board.
/// <c>ChanceTile</c> class is a child class of <c>Tile</c> class. 
/// </summary>
public class ChanceTile : Tile
{
    /// <summary>
    /// Constructor of the <c>ChanceTile</c> class. 
    /// </summary>
    /// <param name="name">A string parameter to initialise the <c>Name</c> Property that derived from the <c>Tile</c>
    /// parent class.</param>
    public ChanceTile(string name) : base(name)
    {
    }

    /// <summary>
    /// The <c>TileAction</c> override method executes the <c>ChanceTile</c> action.
    /// When the <c>CurrentPlayer</c> lands on this tile, a random number between 1 and 3 is generated. If the random number is 1, £2000
    /// is added to the <c>CurrentPlayer</c>'s balance, if the random number is 2, <c>CurrentPlayer</c> loses £2000 and finally
    /// if the random number is 3, the <c>CurrentPlayer</c> gets moved to the jail. 
    /// </summary>
    /// <param name="player">The <c>Player</c> parameter object to call <c>CurrentPlayer</c> methods.</param>
    /// <param name="board">The <c>Board</c> parameter object to access the Monopoly board.</param>
    public override void TileAction(Player player, Board board)
    {
        var random = new Random();

        var rand = random.Next(3) + 1;
        switch (rand)
        {
            case 1:
                player.AddMoney(2000);
                Util.Print($"{player} wins the lottery and is given £2000!");
                break;
            case 2:
                player.SubtractMoney(2000);
                Util.Print($"{player} gets a black eye and loses £2000 trying to double up in the casino.");
                break;
            case 3:
                Util.Print($"{player} was sent to jail for a bank robbery gone wrong.");
                player.MoveToJail(board);
                break;
        }
    }
}