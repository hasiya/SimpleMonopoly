using System;
namespace SimpleMonopoly
{
    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public List<PropertyTile> Properties { get; set; }
        public int Position { get; set; }
        public bool IsInJail { get; set; }
        public bool JustMovedToJail { get; set; }
        public int NumberOfTurns { get; set; }
        


        public Player(string name)
        {
            Name = name;
            Money = 2000;
            Properties = new List<PropertyTile>();
            Position = 0;
            IsInJail = false;
            NumberOfTurns = 0;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public void SubtractMoney(int amount)
        {
            Money -= amount;
        }

        public int RollDie()
        {
            Random random = new Random();
            return random.Next(6) + 1;
        }

        public void AddTurn()
        {
            NumberOfTurns++;
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}

