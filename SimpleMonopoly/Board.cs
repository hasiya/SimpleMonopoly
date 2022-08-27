using System;
namespace SimpleMonopoly
{
    public class Board
    {

        public const int JAIL_POSITION = 2;
        public const int GO_POSITION = 0;

        //Tile[] tiles = new Tile[12];
        public Tile[] Tiles { get; set; }

        public Player[] Players { get; set; }

        public Player CurrentPlayer { get; set; }

        public int PlayRounds { get; set; }


        public Board()
        {
            Players = new Player[2];
            Players[0] = new Player("Boot");
            Players[1] = new Player("Dog");

            PlayRounds = 0;
            initialiaseCurrentPlayer(Players);

            Tiles = new Tile[12];
            Tiles[0] = new GoTile("Go");
            Tiles[1] = new PropertyTile("Old Kent Road",20,200);
            Tiles[2] = new JailTile("Jail");
            Tiles[3] = new PropertyTile("The Strand",80,800);
            Tiles[4] = new ChanceTile("Chance");
            Tiles[5] = new PropertyTile("Fleet Street",160,1600);
            Tiles[6] = new PropertyTile("Oxford Street",180,1800);
            Tiles[7] = new GoToJailTile("Go To Jail");
            Tiles[8] = new PropertyTile("Mayfair",250,2500);
            Tiles[9] = new PropertyTile("Park Lane",250,2500);
            Tiles[10] = new PropertyTile("Whitechapel Road",280,2800);
            Tiles[11] = new PropertyTile("Vine Street",500,5000);


        }

        private void initialiaseCurrentPlayer(Player[] players)
        {
            int player1DiceValue = -1;
            int player2DiceValue = -1;

            do
            {
                player1DiceValue = players[0].RollDie();
                player2DiceValue = players[1].RollDie();

            } while (player1DiceValue == player2DiceValue);

            if (player1DiceValue > player2DiceValue)
                CurrentPlayer = Players[0];
            else if (player2DiceValue > player1DiceValue)
                CurrentPlayer = players[1];
        }


        public void MovePlayer(int numberOfTiels)
        {
            int newPosition = (CurrentPlayer.Position + numberOfTiels) % Tiles.Length;

            Util.Print($"{CurrentPlayer} rolled a {numberOfTiels} and going to \"{Tiles[newPosition]}\" tile.");
            
            if (newPosition < CurrentPlayer.Position)
            {
                Tiles[GO_POSITION].TileAction(CurrentPlayer, this);
            }
            
            
            CurrentPlayer.Position = newPosition;
            CurrentPlayer.AddTurn();

            if (CurrentPlayer.Position != GO_POSITION)
                Tiles[newPosition].TileAction(CurrentPlayer, this);
        }

        public void MovePlayerTo(int TilePossition)
        {
            CurrentPlayer.Position = TilePossition;
            Tiles[TilePossition].TileAction(CurrentPlayer, this);
        }

        public void nextTurn()
        {
            int index = Array.IndexOf(Players, CurrentPlayer);
            if (index == 0)
                CurrentPlayer = Players[1];
            else
                CurrentPlayer = Players[0];

        }

    }
}

