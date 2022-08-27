using System;
namespace SimpleMonopoly
{
    public class Monopoly
    {
        Board board;

        public Monopoly()
        {
            board = new Board();

        }

        public void StartGame()
        {
            Util.Print($"====================");
            Util.Print($"Monopoly - Game Start!");
            Util.Print($"====================");

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

            Util.Print($"====================");

            foreach (var player in board.Players)
            {
                Util.Print($"{player.Name} has ended with £{player.Money}");
            }

            Util.Print($"====================");
            Util.Print($"Monopoly - Game Ended!");
            Util.Print($"====================");
        }


        private bool isGameEnd()
        {
            foreach (var player in board.Players)
            {
                if (player.NumberOfTurns < 20)
                    return false;
            }
            return true;
        }
    }
}

