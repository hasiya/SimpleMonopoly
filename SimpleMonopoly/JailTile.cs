namespace SimpleMonopoly;

/// <summary>
/// <c>JailTile</c> class represents the "Jail" tile in the Monopoly Board.
/// <c>JailTile</c> class is a child class of <c>Tile</c> class. 
/// </summary>
public class JailTile : Tile
{
    /// <summary>
    /// Constructor of the <c>JailTile</c> class. 
    /// </summary>
    /// <param name="name">A string parameter to initialise the <c>Name</c> Property that derived from the <c>Tile</c>
    /// parent class.</param>
    public JailTile(string name) : base(name)
    {
    }

    /// <summary>
    /// The <c>TileAction</c> override method executes the <c>JailTile</c> action.
    /// This method gets executed in three occasions. If the player just landed on this Tile, the console will just output,
    /// stating the <c>CurrentPlayer</c> is just visiting the Jail. if the player gets moved to this tile as a result of <c>ChanceTile</c>
    /// action or <c>GoToJail</c> action the console will output the <c>CurrentPlayer</c> is in Jail. Finally if the
    /// <c>CurrentPlayer</c> is in the Jail, when its their turn (as a result of previous case), the <c>CurrentPlayer</c>
    /// have to roll the dice and get a value greater than or equal to 3 to be released from the Jail. Otherwise the
    /// <c>CurrentPlayer</c> will be stuck in Jail.
    /// </summary>
    /// <param name="player">The <c>Player</c> parameter object to call <c>CurrentPlayer</c> methods.</param>
    /// <param name="board">The <c>Board</c> parameter object to access the Monopoly board.</param>
    public override void TileAction(Player player, Board board)
    {
        if (player.IsInJail && player.JustMovedToJail)
        {
            Util.Print($"{player} is in jail.");
            player.JustMovedToJail = false;
        }
        else if (player.IsInJail)
        {
            var diceValue = Player.RollDice();
            Util.Print($"From jail {player} rolled a {diceValue}.");
            if (diceValue >= 3)
            {
                Util.Print($"{player} has been released from jail!");
                player.IsInJail = false;
            }
            else
            {
                Util.Print($"{player} is stuck in jail!");
            }
        }
        else
        {
            Util.Print($"{player} is visiting jail.");
        }
    }
}