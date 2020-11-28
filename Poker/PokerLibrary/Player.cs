using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class Player: IComparable<Player>
    {
        public string Name { get; set; }
       // public int Total { get; set; }
        public Card[] PlayerHand { get; set; } = new Card[5];

        public HandValue handValue { get; set; } = new HandValue();

        public int CompareTo(Player other)
        {
            if (handValue.handRanking < other.handValue.handRanking) return 1;
            else if (handValue.handRanking > other.handValue.handRanking) return -1;

            if (handValue.Total < other.handValue.Total) return 1;
            else if (handValue.Total > other.handValue.Total) return -1;

            else
            {
                for (int i = DealQueueCards.HANDSIZE - 1; i > 0; i--)
                {
                    if (PlayerHand[i].MyValue < other.PlayerHand[i].MyValue) return 1;
                    if (PlayerHand[i].MyValue > other.PlayerHand[i].MyValue) return -1;
                }
                return 0;
            }
        }

        private int compareHands(Card[]handOne, Card[]handTwo)
        {
            for (int i = DealQueueCards.HANDSIZE-1; i > 0; i--)
            {
                if (handOne[i].MyValue > handTwo[i].MyValue) return 1;
                if (handOne[i].MyValue < handTwo[i].MyValue) return -1;
            }
            return 0;
        }

        
    }
}
