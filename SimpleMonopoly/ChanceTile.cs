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
                    Util.Print($"{player.Name} wins the lottery and is given £2000");
                    break;
                case 2:
                    player.SubtractMoney(2000);
                    Util.Print($"{player.Name} gets a black eye and loses £2000 trying to double up in the casini.")
                    break;
                case 3:

                    break;
                default:
                    break;
            }
        }
    }
}

