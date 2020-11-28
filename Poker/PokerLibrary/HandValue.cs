using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class HandValue
    {

        public enum HandRanking
        {
            HighCard,
            OnePair,
            ThreeKind,
            Flush
        }

      
        public int Total { get; set; }
        public HandRanking handRanking { get; set; }
      

    }
}
