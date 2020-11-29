using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  PokerLibrary
{
    class HandEvaluator 
    {
        private Hand _hand;

        public HandEvaluator(Hand hand)
        {
            _hand = hand;
        }

        public void EvaluateHand()
        {
            if (!Flush() && !ThreeOfKind() && !OnePair())
            {
                _hand.Ranking.RankingTypes = HandRanking.Ranking.HighCard;
            }
        }
      
        private bool Flush()
        {
            //Check if a player has 5 cards with the same SUIT
            var query = _hand.Cards.GroupBy(x => x.MySuit)
                .Where(g => g.Count() == 5)
                .Select(c => c.Count())
                .FirstOrDefault();

            if(query == 5)
            {
                _hand.Ranking.RankingTypes = HandRanking.Ranking.Flush;
                return true;
            }

            return false;
        }

        private bool ThreeOfKind()
        {
            //Check if a player has 3 cards with the same SUIT, store the total value of this combination
            var query = _hand.Cards.GroupBy(x => x.MyValue)
           .Where(g => g.Count() > 2)
           .Select(y => new {count = y.Count(), total = (int)y.Key * y.Count() })
           .FirstOrDefault();
            int count = query is null ? 0 : query.count;
            if(count == 3)
            {
                _hand.CombinationTotal = query is null ? 0 : query.total;
                _hand.Ranking.RankingTypes = HandRanking.Ranking.ThreeKind;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            //Check if a player has 2 cards with the same SUIT, store the total value of this combination
            var query = _hand.Cards.GroupBy(x => x.MyValue)
            .Where(g => g.Count() > 1)
            .Select(y => new {count = y.Count(), total = (int)y.Key * y.Count() })
            .LastOrDefault();
            int count = query is null ? 0 : query.count;
            if (count == 2)
            {
                _hand.CombinationTotal = query is null ? 0 : query.total;
                _hand.Ranking.RankingTypes = HandRanking.Ranking.OnePair;
                return true;
            }
            return false;
        }
    }
}
