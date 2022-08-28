namespace SimpleMonopoly;

/// <summary>
/// <c>GoToJailTile</c> class represents the "Go To Jail" tile in the Monopoly Board.
/// <c>GoToJailTile</c> class is a child class of <c>Tile</c> class. 
/// </summary>
public class GoToJailTile : Tile
{
    /// <summary>
    /// Constructor of the <c>GoToJailTile</c> class. 
    /// </summary>
    /// <param name="name">A string parameter to initialise the <c>Name</c> Property that derived from the <c>Tile</c>
    /// parent class.</param>
    public GoToJailTile(string name) : base(name)
    {
    }

    /// <summary>
    /// The <c>TileAction</c> override method executes the <c>GoToJailTile</c> action.
    ///  When the <c>CurrentPlayer</c> lands on this tile, the player gets moved to the Jail tile. 
    /// </summary>
    /// <param name="player">The <c>Player</c> parameter object to call <c>CurrentPlayer</c> methods.</param>
    /// <param name="board">The <c>Board</c> parameter object to access the Monopoly board.</param>
    public override void TileAction(Player player, Board board)
    {
        Util.Print($"{player} is going to jail!");
        player.MoveToJail(board);
    }
}