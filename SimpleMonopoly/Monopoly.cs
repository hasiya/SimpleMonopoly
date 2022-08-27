using System;
namespace SimpleMonopoly
{
    /// <summary>
    /// The Monopoly Game class. 
    /// </summary>
    public class Monopoly
    {
        Board board;
        const int NumberOfTurns = 20;

        /// <summary>
        /// Monopoly class constructor.
        /// When the Monopoly object is created it prints the game start message and initialise the <c>board</c> object.
        /// </summary>
        public Monopoly()
        {
            Util.Print("=====================================");
            Util.Print("Monopoly - Game Start!");
            Util.Print("=====================================");
            Util.Print("");
            board = new Board();

        }

        /// <summary>
        /// StartGame() Method.
        /// This is the starting point of the game.
        /// The <code>while(!isGameEnd())</code> loop checks if the game end condintions have met.
        /// If the game end conditions haven't met it will let the current player to play their turn.
        /// At the end of each iteration the current player changes.
        ///
        /// When <c>while</c> loop ends, it will print each player's finishing balance and the properties they own. 
        /// </summary>
        public void StartGame()
        {
            while (!isGameEnd())
            {
                if (!board.CurrentPlayer.IsInJail)
                {
                    int diceValue = board.CurrentPlayer.RollDie();
                    board.MovePlayer(diceValue);
                }
                else
                {
                    board.Tiles[Board.JAIL_POSITION].TileAction(board.CurrentPlayer, board);
                }

                board.nextTurn();
                Util.Print("");
            }

            Util.Print("-----------------------------------------------");

            foreach (var player in board.Players)
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
        /// isEndGame() method.
        /// This method checks if each player had predefined number of turns in the game to end the game.
        /// If any of the player haven't had their number of turns the game won't end. 
        /// </summary>
        /// <returns>
        /// A Boolean value representing of the game should end or not.
        /// </returns>
        private bool isGameEnd()
        {
            foreach (var player in board.Players)
            {
                if (player.NumberOfTurns < NumberOfTurns)
                    return false;
            }
            return true;
        }
    }
}

