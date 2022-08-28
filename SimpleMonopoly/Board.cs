namespace SimpleMonopoly;

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


    public Board()
    {
        Players = new Player[2];
        Players[0] = new Player("Boot");
        Players[1] = new Player("Dog");

        PlayRounds = 0;
        InitialiseCurrentPlayer(Players);

        var propertyDictionaryIndex = 0;
        Tiles = new Tile[12];
        for (var i = 0; i < Tiles.Length; i++)
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

    public Tile[] Tiles { get; set; }

    public Player[] Players { get; set; }

    public Player CurrentPlayer { get; set; }

    public int PlayRounds { get; set; }

    private void InitialiseCurrentPlayer(Player[] players)
    {
        int player1DiceValue;
        int player2DiceValue;


        Util.Print("Finding who is going first.");

        do
        {
            player1DiceValue = Player.RollDie();
            player2DiceValue = Player.RollDie();

            if (player1DiceValue != player2DiceValue)
                continue;

            Util.Print($"{players[0]} and {players[1]} both rolled a {player1DiceValue}!");
            Util.Print("Both players are rolling the dice again.");
        } while (player1DiceValue == player2DiceValue);

        if (player1DiceValue > player2DiceValue)
            CurrentPlayer = Players[0];
        else if (player2DiceValue > player1DiceValue)
            CurrentPlayer = players[1];

        Util.Print($"{players[0]} rolled a {player1DiceValue} and {players[1]} rolled a {player2DiceValue}.");
        Util.Print($"{CurrentPlayer} rolled the higher value and going first.");
        Util.Print("-----------------------------------------------");
        Util.Print("");
    }


    public void MovePlayer(int numberOfTiles)
    {
        var newPosition = (CurrentPlayer.Position + numberOfTiles) % Tiles.Length;

        Util.Print($"{CurrentPlayer} rolled a {numberOfTiles} and going to \"{Tiles[newPosition]}\" tile.");

        if (newPosition < CurrentPlayer.Position) Tiles[GoPosition].TileAction(CurrentPlayer, this);


        CurrentPlayer.Position = newPosition;
        CurrentPlayer.AddTurn();

        if (CurrentPlayer.Position != GoPosition)
            Tiles[newPosition].TileAction(CurrentPlayer, this);
    }

    public void MovePlayerTo(int tilePosition)
    {
        CurrentPlayer.Position = tilePosition;
        Tiles[tilePosition].TileAction(CurrentPlayer, this);
    }

    public void NextTurn()
    {
        var index = Array.IndexOf(Players, CurrentPlayer);
        CurrentPlayer = index == 0 ? Players[1] : Players[0];
    }
}