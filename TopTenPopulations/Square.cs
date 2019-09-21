using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsCrosses
{
    public enum Player { Noone = 0, Noughts, Crosses}
    public struct Square
    {
        public Player Owner { get; }
        
        public Square (Player Owner)
        {
            this.Owner = Owner;
        }
        public override string ToString()
        {
            switch (Owner)
            {
                case Player.Noone:
                    return ".";
                case Player.Crosses:
                    return "X";
                case Player.Noughts:
                    return "O";
                default:
                    throw new Exception("Invalid state");
            }
        }
    }
}
