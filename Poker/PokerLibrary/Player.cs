using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public Card[] Hand { get; set; } = new Card[5];
    }
}
