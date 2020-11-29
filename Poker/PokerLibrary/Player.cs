using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class Player: IComparable<Player>
    {
        public string Name { get; set; }
        public Hand PlayerHand { get; set; } = new Hand();
      
        public int CompareTo(Player other)
        {
            //Compare players by highest Hand Ranking
            if (PlayerHand.Ranking.RankingTypes < other.PlayerHand.Ranking.RankingTypes) return 1;
            else if (PlayerHand.Ranking.RankingTypes > other.PlayerHand.Ranking.RankingTypes) return -1;
            // If players have same Hand Ranking, compare by total value of these same rankings
            if (PlayerHand.CombinationTotal < other.PlayerHand.CombinationTotal) return 1;
            else if (PlayerHand.CombinationTotal > other.PlayerHand.CombinationTotal) return -1;
            //In case rankings and their total values are same, compare by kickers
            else
            {
                for (int i = PlayerHand.HandSize - 1; i > 0; i--)
                {
                    if (PlayerHand.Cards[i].MyValue < other.PlayerHand.Cards[i].MyValue) return 1;
                    if (PlayerHand.Cards[i].MyValue > other.PlayerHand.Cards[i].MyValue) return -1;
                }
                return 0;
            }
        }
       
    }
}
