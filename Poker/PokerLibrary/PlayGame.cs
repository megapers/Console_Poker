using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerLibrary
{
    public class PlayGame
    {
        private List<Player> _players;
        private Deck _queueDeck = new Deck();
        private Queue<Card> _deck;
        public PlayGame(List<Player> players)
        {
            _players = players;
        }

        public void Play()
        {
            _deck = _queueDeck.CreateCards();
            Deal();
            EvaluateHands();
            new DrawCards().DisplayCards(_players);
            ResetPlayers();
        }

        public void Deal()
        {
            for (int i = 0; i < _players[0].PlayerHand.HandSize; i++)
            {
                foreach (var player in _players)
                {
                    player.PlayerHand.Cards[i] = _deck.Dequeue();
                }
            }
            foreach (var player in _players)
            {
                player.PlayerHand.Cards = player.PlayerHand.Cards.OrderBy(h => h.MyValue).ToArray();
            }

            //********************************TEST 2 winners scenario*************************************
            //To test comment the above code in Deal() function and uncomment code below, 
            //Make sure to only add 3 players in Program.cs
            //Hardcoded for 3 players 
            //This test is reproducing a scenario when 2 players win
            //
            // Card[] testPlayer1 = new Card[]
            // {
            //     new Card{MySuit = Card.SUIT.SPADES, MyValue = Card.VALUE.ACE },
            //     new Card{MySuit = Card.SUIT.SPADES, MyValue = Card.VALUE.ACE },
            //     new Card{MySuit = Card.SUIT.SPADES, MyValue = Card.VALUE.KING },
            //     new Card{MySuit = Card.SUIT.SPADES, MyValue = Card.VALUE.KING },
            //     new Card{MySuit = Card.SUIT.SPADES, MyValue = Card.VALUE.KING }
            // };

            // Card[] testPlayer2 = new Card[]
            // {
            //     new Card{MySuit = Card.SUIT.CLUBS, MyValue = Card.VALUE.ACE },
            //     new Card{MySuit = Card.SUIT.CLUBS, MyValue = Card.VALUE.ACE },
            //     new Card{MySuit = Card.SUIT.CLUBS, MyValue = Card.VALUE.KING },
            //     new Card{MySuit = Card.SUIT.CLUBS, MyValue = Card.VALUE.KING },
            //     new Card{MySuit = Card.SUIT.CLUBS, MyValue = Card.VALUE.KING }
            // };

            // Card[] testPlayer3 = new Card[]
            //{
            //     new Card{MySuit = Card.SUIT.DIAMONDS, MyValue = Card.VALUE.THREE },
            //     new Card{MySuit = Card.SUIT.CLUBS, MyValue = Card.VALUE.FIVE },
            //     new Card{MySuit = Card.SUIT.CLUBS, MyValue = Card.VALUE.TEN },
            //     new Card{MySuit = Card.SUIT.HEARTS, MyValue = Card.VALUE.ACE },
            //     new Card{MySuit = Card.SUIT.SPADES, MyValue = Card.VALUE.JACK }
            //};

            // _players[0].PlayerHand.Cards = testPlayer1;
            // _players[1].PlayerHand.Cards = testPlayer2;
            // _players[2].PlayerHand.Cards = testPlayer3;
        }

        private void EvaluateHands()
        {
            foreach (var player in _players)
            {
                new HandEvaluator(player.PlayerHand).EvaluateHand();
            }
            //Here the CompareTo() method is called because Player class implements IComparable interface
            _players.Sort();
        }

        private void ResetPlayers()
        {
            foreach(var player in _players)
            {
                player.PlayerHand.CombinationTotal = 0;
            }
        }
    }
}
