using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class HandRanking
    {
        public enum Ranking
        {
            HighCard,
            OnePair,
            ThreeKind,
            Flush
        }
      
        public Ranking RankingTypes { get; set; }
    }
}
