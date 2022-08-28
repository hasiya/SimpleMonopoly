namespace SimpleMonopoly;

/// <summary>
/// The <c>Board</c> Class represent the Monopoly board with different tiles with different actions.
/// The <c>Board</c> class contains following Properties to create the <c>Board</c> object.
/// <c>Tiles</c> Property to store the <c>Board</c> tiles in an Array of <c>Tile</c> objects that represent the Monopoly Board.
/// <c>Players</c> Property to store the <c>Player</c> objects in an Array.
/// <c>CurrentPlayer</c> Property to store the current player <c>Player</c> object.
/// </summary>
public class Board
{
    public const int JailPosition = 2;
    private const int GoPosition = 0;

    //Tile[] tiles = new Tile[12];
    private readonly Dictionary<string, int> _propertyData = new()
    {
        { "Old Kent Road", 20 },
        { "The Strand", 80 },
        { "Fleet Street", 160 },
        { "Oxford Street", 180 },
        { "Mayfair", 250 },
        { "Park Lane", 250 },
        { "Whitechapel Road", 280 },
        { "Vine Street", 500 }
    };

    public Tile[] Tiles { get; set; }

    public Player[] Players { get; set; }

    public Player CurrentPlayer { get; set; }


    /// <summary>
    /// The <c>Board</c> class constructor creates the Monopoly board with correct tiles, initialise the <c>Player</c> array
    /// and set the <c>CurrentPlay</c> by calling the <c>InitialiseCurrentPlayer</c> method. 
    /// </summary>
    public Board()
    {
        Players = new Player[2];
        Players[0] = new Player("Boot");
        Players[1] = new Player("Dog");

        InitialiseCurrentPlayer();

        var propertyDictionaryIndex = 0;
        Tiles = new Tile[12];
        for (var i = 0; i < Tiles.Length; i++)
        {
            switch (i)
            {
                case 0:
                    Tiles[i] = new GoTile("Go");
                    break;
                case 2:
                    Tiles[i] = new JailTile("Jail");
                    break;
                case 4:
                    Tiles[i] = new ChanceTile("Chance");
                    break;
                case 7:
                    Tiles[i] = new GoToJailTile("Go To Jail");
                    break;
                default:
                    var property = _propertyData.ElementAt(propertyDictionaryIndex);
                    Tiles[i] = new PropertyTile(property.Key, property.Value, property.Value * 10);
                    propertyDictionaryIndex++;
                    break;
            }
        }

        // Tiles[0] = new GoTile("Go");
        // Tiles[1] = new PropertyTile("Old Kent Road",20,200);
        // Tiles[2] = new JailTile("Jail");
        // Tiles[3] = new PropertyTile("The Strand",80,800);
        // Tiles[4] = new ChanceTile("Chance");
        // Tiles[5] = new PropertyTile("Fleet Street",160,1600);
        // Tiles[6] = new PropertyTile("Oxford Street",180,1800);
        // Tiles[7] = new GoToJailTile("Go To Jail");
        // Tiles[8] = new PropertyTile("Mayfair",250,2500);
        // Tiles[9] = new PropertyTile("Park Lane",250,2500);
        // Tiles[10] = new PropertyTile("Whitechapel Road",280,2800);
        // Tiles[11] = new PropertyTile("Vine Street",500,5000);
    }

    /// <summary>
    /// <c>InitialiseCurrentPlayer</c> method initialise the current player by rolling the dice for both players and who
    /// ever gets the highest value gets initialised to the <c>CurrentPlayer</c> Property. if the both players roll the
    /// same value they will roll the dice until both players gets different values. 
    /// </summary>
    private void InitialiseCurrentPlayer()
    {
        int player1DiceValue;
        int player2DiceValue;

        Util.Print("Finding who is going first.");

        do
        {
            player1DiceValue = Player.RollDice();
            player2DiceValue = Player.RollDice();

            if (player1DiceValue != player2DiceValue)
                continue;

            Util.Print($"{Players[0]} and {Players[1]} both rolled a {player1DiceValue}!");
            Util.Print("Both players are rolling the dice again.");
        } while (player1DiceValue == player2DiceValue);

        if (player1DiceValue > player2DiceValue)
            CurrentPlayer = Players[0];
        else if (player2DiceValue > player1DiceValue)
            CurrentPlayer = Players[1];

        Util.Print($"{Players[0]} rolled a {player1DiceValue} and {Players[1]} rolled a {player2DiceValue}.");
        Util.Print($"{CurrentPlayer} rolled the higher value and going first.");
        Util.Print("-----------------------------------------------");
        Util.Print("");
    }

    /// <summary>
    /// <c>MovePlayer</c> method calculate the current players new position, set the <c>CurrentPlayer</c>'s <c>Position</c>
    /// Property to the new calculated position and triggers the <c>TileAction</c> of the new position.
    /// If the <c>CurrentPlayer</c> passes or landed on the "Go" tile the <c>GoTile</c> class's <c>TileAction</c> method
    /// gets called.
    /// </summary>
    /// <param name="numberOfTiles">An Integer parameter to get the number of tile the <c>CurrentPlayer</c> is moving</param>
    public void MovePlayer(int numberOfTiles)
    {
        var newPosition = (CurrentPlayer.Position + numberOfTiles) % Tiles.Length;

        Util.Print($"{CurrentPlayer} rolled a {numberOfTiles} and is going to \"{Tiles[newPosition]}\" tile.");

        if (newPosition < CurrentPlayer.Position)
            Tiles[GoPosition].TileAction(CurrentPlayer, this);

        CurrentPlayer.Position = newPosition;
        CurrentPlayer.AddTurn();

        if (CurrentPlayer.Position != GoPosition)
            Tiles[newPosition].TileAction(CurrentPlayer, this);
    }

    /// <summary>
    /// <c>MovePlayerTo</c> method moves the <c>CurrentPlayer</c> to a specific position of the board. 
    /// </summary>
    /// <param name="tilePosition">An Integer parameter to get the position of the <c>CurrentPlayer</c> is moving to</param>
    public void MovePlayerTo(int tilePosition)
    {
        CurrentPlayer.Position = tilePosition;
        Tiles[tilePosition].TileAction(CurrentPlayer, this);
    }

    /// <summary>
    /// <c>NextTurn</c> method changes the <c>CurrentPlayer</c> to the next <c>Player</c> object in the <c>Players</c>
    /// array
    /// </summary>
    public void NextTurn()
    {
        var index = Array.IndexOf(Players, CurrentPlayer);
        CurrentPlayer = index == 0 ? Players[1] : Players[0];
    }
}