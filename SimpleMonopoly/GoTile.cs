﻿using System;
namespace SimpleMonopoly
{
    public class GoTile:Tile
    {
        public GoTile(string name) : base(name)
        {
        }

        public override void TileAction(Player player, Board board)
        {
            player.AddMoney(200);
            Util.Print($"{player.Name} is awarded £200 for passing/landing on Go!");
            
        }
    }
}
