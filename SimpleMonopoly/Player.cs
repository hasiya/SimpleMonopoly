namespace SimpleMonopoly;

/// <summary>
///     Player class
///     The player class contains following properties to create the player object.
///     <c>Name</c> property to store player name
///     <c>Money</c> property to store the player balance
///     <c>Properties</c> property stores the list of propertis the player owns.
///     <c>Position</c> property stores the position of the playre in the Board.
///     <c>IsInJail</c> property to store the boolean value of if the player is in jail or not.
///     <c>JustMovedToJail</c> property to store the boolean value of if the player just moved to jail or not.
///     <c>NumberOfTurns</c> property to store the number of dice turns the player had.
/// </summary>
public class Player
{
    public Player(string name, int money = 2000)
    {
        Name = name;
        Money = money;
        Properties = new List<PropertyTile>();
        Position = 0;
        IsInJail = false;
        NumberOfTurns = 0;
    }

    public string Name { get; }
    public int Money { get; private set; }
    public List<PropertyTile> Properties { get; }
    public int Position { get; set; }
    public bool IsInJail { get; set; }
    public bool JustMovedToJail { get; set; }
    public int NumberOfTurns { get; private set; }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public void SubtractMoney(int amount)
    {
        Money -= amount;
    }

    public void PayAnotherPlayer(Player otherPlayer, int cost)
    {
        SubtractMoney(cost);
        otherPlayer.AddMoney(cost);
    }

    public static int RollDie()
    {
        var random = new Random();
        return random.Next(6) + 1;
    }

    public void AddTurn()
    {
        NumberOfTurns++;
    }

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

    public void MoveToJail(Board board)
    {
        IsInJail = true;
        JustMovedToJail = true;
        board.MovePlayerTo(Board.JailPosition);
    }

    public override string? ToString()
    {
        return Name;
    }
}