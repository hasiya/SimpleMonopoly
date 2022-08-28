namespace SimpleMonopoly;

/// <summary>
/// <c>GoTile</c> class represents the "Go" tile in the Monopoly Board.
/// <c>GoTile</c> class is a child class of <c>Tile</c> class. 
/// </summary>
public class GoTile : Tile
{
    /// <summary>
    /// Constructor of the <c>GoTile</c> class. 
    /// </summary>
    /// <param name="name">A string parameter to initialise the <c>Name</c> Property that derived from the <c>Tile</c>
    /// parent class.</param>
    public GoTile(string name) : base(name)
    {
    }

    /// <summary>
    /// The <c>TileAction</c> override method executes the <c>GoTile</c> action.
    /// When the <c>CurrentPlayer</c> lands on or passes the "Go" tile in the board, £200 gets added to the <c>CurrentPlayer</c>'s balance.  
    /// </summary>
    /// <param name="player">The <c>Player</c> parameter object to call <c>CurrentPlayer</c> methods.</param>
    /// <param name="board">The <c>Board</c> parameter object to access the Monopoly board.</param>
    public override void TileAction(Player player, Board board)
    {
        player.AddMoney(200);
        Util.Print($"{player} is awarded £200 for passing/landing on Go!");
    }
}