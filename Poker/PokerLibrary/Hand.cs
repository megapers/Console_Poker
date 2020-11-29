using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class Hand
    {
        private const int HANDSIZE = 5;
        public int HandSize
        {
            get { return HANDSIZE; }
        }
        public Card[] Cards {get; set; } = new Card[HANDSIZE];
        public HandRanking Ranking { get; set; } = new HandRanking();
        public int CombinationTotal { get; set; }
        

        
    }
}
