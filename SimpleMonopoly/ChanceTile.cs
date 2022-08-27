using System;
namespace SimpleMonopoly
{
    public class ChanceTile : Tile
    {
        public ChanceTile(string name) : base(name)
        {
        }

        public override void TileAction(Player player, Board board)
        {
            Random random = new Random();
            
            int rand = random.Next(3) + 1;
            switch (rand)
            {
                case 1:
                    player.AddMoney(2000);
                    Util.Print($"{player} wins the lottery and is given £2000");
                    break;
                case 2:
                    player.SubtractMoney(2000);
                    Util.Print($"{player} gets a black eye and loses £2000 trying to double up in the casini.");
                    break;
                case 3:
                    Util.Print($"{player} was sent to jail for a bank roberry");
                    player.JustMovedToJail = true;
                    player.IsInJail = true;
                    board.MovePlayerTo(Board.JAIL_POSITION);                    
                    break;
                default:
                    break;
            }
        }
    }
}

