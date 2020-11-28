using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  PokerLibrary

{
    //public enum HandRanking
    //{
    //    HighCard,
    //    OnePair,
    //    ThreeKind,
    //    Flush
    //}

    //public struct HandValue
    //{
    //    public int Total { get; set; }
    //    public int HighestCard { get; set; }
    //}

    class HandEvaluator 
    {
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        private Player _player;
        //private HandValue handValue;

        public HandEvaluator(Player player)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadesSum = 0;
            _player = player;
            //cards = new Card[5];
            //Cards = sortedHand;
            //handValue = new HandValue();
        }

        //public HandValue HandValues
        //{
        //    get { return handValue; }
        //    set { handValue = value; }
        //}

        //public Card[] Cards
        //{
        //    get { return cards; }
        //    set
        //    {
        //        for(int i = 0; i < cards.Length; i++)
        //        {
        //            cards[i] = value[i];
        //        }
        //    }
        //}

        public void EvaluateHand()
        {
            //get the number of each suit on hand
            getNumberOfSuit();
            if (!Flush() && !ThreeOfKind() && !OnePair())
            {
                _player.handValue.handRanking = HandValue.HandRanking.HighCard;
            }
        }

        private void getNumberOfSuit()
        {
            foreach (var element in _player.PlayerHand)
            {
                if (element.MySuit == Card.SUIT.HEARTS)
                    heartsSum++;
                else if (element.MySuit == Card.SUIT.DIAMONDS)
                    diamondSum++;
                else if (element.MySuit == Card.SUIT.CLUBS)
                    clubSum++;
                else if (element.MySuit == Card.SUIT.SPADES)
                    spadesSum++;
            }
        }


        private bool Flush()
        {
            //if all suits are the same
            if (heartsSum == 5 || diamondSum == 5 || clubSum == 5 || spadesSum == 5)
            {
                //if flush, the player with higher cards win
                //whoever has the last card the highest, has automatically all the cards total higher
                _player.handValue.handRanking = HandValue.HandRanking.Flush;
                _player.handValue.Total = (int)_player.PlayerHand[4].MyValue;
                return true;
            }

            return false;
        }


        private bool ThreeOfKind()
        {
            var query = _player.PlayerHand.GroupBy(x => x.MyValue)
           .Where(g => g.Count() > 2)
           .Select(y => new { hightCard = (int)y.Key, count = y.Count(), total = (int)y.Key * y.Count() })
           .FirstOrDefault();
            int count = query is null ? 0 : query.count;
            if(count == 3)
            {
                _player.handValue.Total = query is null ? 0 : query.total;
                _player.handValue.handRanking = HandValue.HandRanking.ThreeKind;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            var query = _player.PlayerHand.GroupBy(x => x.MyValue)
            .Where(g => g.Count() > 1)
            .Select(y => new { hightCard = (int)y.Key, count = y.Count(), total = (int)y.Key * y.Count() })
            .LastOrDefault();
            int count = query is null ? 0 : query.count;
            if (count == 2)
            {
                _player.handValue.Total = query is null ? 0 : query.total;
                _player.handValue.handRanking = HandValue.HandRanking.OnePair;
                return true;
            }
            return false;
        }

    }
}
