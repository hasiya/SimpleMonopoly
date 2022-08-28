namespace SimpleMonopoly;

/// <summary>
/// Tile abstract class.
/// This class is inherited by all the different Tile classes in the Monopoly Board.  
/// The class contains a string <c>Name</c> Property 
/// </summary>
public abstract class Tile
{
    public string Name { get; set; }

    /// <summary>
    /// Constructor of <c>Tile</c> class. 
    /// </summary>
    /// <param name="name">A string parameter to initialise the <c>Name</c> Property</param>
    public Tile(string name)
    {
        Name = name;
    }

    /// <summary>
    /// The <c>TileAction</c> abstract method gets implemented by all the different Tile class that inherits this <c>Tile</c>
    /// class.
    /// </summary>
    /// <param name="player">The <c>Player</c> parameter object to call <c>CurrentPlayer</c> methods.</param>
    /// <param name="board">The <c>Board</c> parameter object to access the Monopoly board.</param>
    public abstract void TileAction(Player player, Board board);

    public override string? ToString()
    {
        return Name;
    }
}