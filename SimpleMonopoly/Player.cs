namespace SimpleMonopoly;

/// <summary>
/// The <c>Player</c> class represent the Monopoly Player. 
/// The <c>Player</c> class contains following properties to create the <c>Player</c> object.
/// <c>Name</c> Property to store <c>Player</c> name
/// <c>Money</c> Property to store the <c>Player</c> balance
/// <c>Properties</c> Property stores the list of properties the player owns.
/// <c>Position</c> Property stores the position of the player in the Board.
/// <c>IsInJail</c> Property to store the boolean value of if the player is in jail or not.
/// <c>JustMovedToJail</c> Property to store the boolean value of if the player just moved to jail or not.
/// <c>NumberOfTurns</c> Property to store the number of dice turns the player had.
/// </summary>
public class Player
{
    public string Name { get; }
    public int Money { get; private set; }
    public List<PropertyTile> Properties { get; }
    public int Position { get; set; }
    public bool IsInJail { get; set; }
    public bool JustMovedToJail { get; set; }
    public int NumberOfTurns { get; private set; }

    /// <summary>
    /// <c>Player</c> class constructor. The constructor takes 2 parameters <c>name</c> and <c>money</c> to initialise <c>Name</c>
    /// and <c>Money</c> Properties. The constructor also initialise <c>Properties</c>, <c>Position</c>, <c>IsInJain</c>,
    /// <c>JustMovedToJail</c> and <c>NumberOfTurns</c> Properties.
    /// 
    /// </summary>
    /// <param name="name">A string parameter to initialise the <c>Name</c> Property.</param>
    /// <param name="money">An Integer parameter to initialise the <c>Money</c> Property.</param>
    public Player(string name, int money = 2000)
    {
        Name = name;
        Money = money;
        Properties = new List<PropertyTile>();
        Position = 0;
        IsInJail = false;
        JustMovedToJail = false;
        NumberOfTurns = 0;
    }

    /// <summary>
    /// <c>AddMoney</c> method adds a specific amount to the <c>Money</c> Property.
    /// </summary>
    /// <param name="amount">An Integer parameter to get the amount to add to the <c>Money</c> Property.</param>
    public void AddMoney(int amount)
    {
        Money += amount;
    }

    /// <summary>
    /// <c>SubtractMoney</c> method subtracts a specific amount from the <c>Money</c> Property.
    /// </summary>
    /// <param name="amount">An Integer parameter to get the amount to subtract from the <c>Money</c> Property.</param>
    public void SubtractMoney(int amount)
    {
        Money -= amount;
    }

    /// <summary>
    /// <c>PayAnotherPlayer</c> method subtracts a specific amount form the <c>this</c> Player and adds that same amount
    /// to another player.
    /// </summary>
    /// <param name="otherPlayer"><c>Player</c> object parameter to update the <c>Money</c> Property with <c>AddMoney</c> method</param>
    /// <param name="cost">An Integer parameter to get the amount to subtract from <c>this</c> Player and add to the <otherPlayer />
    /// </param>
    public void PayAnotherPlayer(Player otherPlayer, int cost)
    {
        SubtractMoney(cost);
        otherPlayer.AddMoney(cost);
    }

    /// <summary>
    /// <c>RollDice</c> a static method to get a random number between 1 and 6. Representing a dice roll. 
    /// </summary>
    /// <returns>Returns an Integer value between 1 and 6</returns>
    public static int RollDice()
    {
        var random = new Random();
        return random.Next(6) + 1;
    }

    /// <summary>
    /// <c>AddTurn</c> method adds 1 to the <c>NumberOfTurns</c> Property.
    /// </summary>
    public void AddTurn()
    {
        NumberOfTurns++;
    }

    /// <summary>
    /// <c>MoveToJail</c> method calls the <c>MovePlayerTo</c> method in <c>Board</c> class with the position of the
    /// Jail Tile to move <c>this</c> Player to the Jail tile in the board. The <c>IsInJail</c> and <c>JustMovedToJail</c>
    /// Parameters are set to True.
    ///  
    /// </summary>
    /// <param name="board">The <c>Board</c> object parameter is used to call the <c>MoverPlayerTo</c> method.</param>
    public void MoveToJail(Board board)
    {
        IsInJail = true;
        JustMovedToJail = true;
        board.MovePlayerTo(Board.JailPosition);
    }

    /// <summary>
    /// <c>PrintMoneyAndProperties</c> method prints the player's <c>Money</c> balance and the <c>Properties</c> they have. 
    /// </summary>
    public void PrintMoneyAndProperties()
    {
        Util.Print($"{this} has ended with £{Money}");
        if (Properties.Count == 0)
        {
            Util.Print($"{this} does not have any properties.");
        }
        else
        {
            Util.Print($"{this} has following properties.");

            foreach (var property in Properties) Util.Print($"\t-{property}");
        }
    }

    /// <summary>
    /// <c>ToString</c> override method to display the <c>Player</c> name when printing the <c>Player</c> object.
    /// </summary>
    /// <returns>Return the <c>Name</c> Property value. </returns>
    public override string? ToString()
    {
        return Name;
    }
}