using System;
namespace SimpleMonopoly
{
    public class Player
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public int Position { get; set; }
        List<PropertyTile> properties = new List<PropertyTile>();
        public bool IsInJail { get; set; }


        public Player(string name)
        {
            Name = name;
            Money = 2000;
            Position = 0;
            IsInJail = false;
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

        public override string? ToString()
        {
            return $"{Name} - {Money}";
        }
    }
}

