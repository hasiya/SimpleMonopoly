namespace SimpleMonopoly;

/// <summary>
///     The Monopoly Game class.
/// </summary>
public class Monopoly
{
    private const int GameNumberOfTurns = 20;
    private readonly Board _board;

    /// <summary>
    ///     Monopoly class constructor.
    ///     When the Monopoly object is created it prints the game start message and initialise the <c>board</c> object.
    /// </summary>
    public Monopoly()
    {
        Util.Print("=====================================");
        Util.Print("Monopoly - Game Start!");
        Util.Print("=====================================");
        Util.Print("");
        _board = new Board();
    }

    /// <summary>
    ///     StartGame() Method.
    ///     This is the starting point of the game.
    ///     The <code>while(!isGameEnd())</code> loop checks if the game end conditions have met.
    ///     If the game end conditions haven't met it will let the current player to play their turn.
    ///     At the end of each iteration the current player changes.
    ///     When <c>while</c> loop ends, it will print each player's finishing balance and the properties they own.
    /// </summary>
    public void StartGame()
    {
        while (!IsGameEnd())
        {
            if (!_board.CurrentPlayer.IsInJail)
            {
                var diceValue = Player.RollDie();
                _board.MovePlayer(diceValue);
                Util.Print($"{_board.CurrentPlayer}\'s balance - £{_board.CurrentPlayer.Money}");
            }
            else
            {
                _board.Tiles[Board.JailPosition].TileAction(_board.CurrentPlayer, _board);
            }

            _board.NextTurn();
            Util.Print("");
        }

        Util.Print("-----------------------------------------------");

        foreach (var player in _board.Players)
        {
            //Util.Print($"{player} has ended with £{player.Money}");
            player.PrintMoneyAndProperties();
            Util.Print("");
        }


        Util.Print("=====================================");
        Util.Print("Monopoly - Game Ended!");
        Util.Print("=====================================");
    }

    /// <summary>
    ///     isEndGame() method.
    ///     This method checks if each player had predefined number of turns in the game to end the game.
    ///     If any of the player haven't had their number of turns the game won't end.
    /// </summary>
    /// <returns>
    ///     A Boolean value representing of the game should end or not.
    /// </returns>
    private bool IsGameEnd()
    {
        foreach (var player in _board.Players)
            if (player.NumberOfTurns < GameNumberOfTurns)
                return false;
        return true;
    }
}