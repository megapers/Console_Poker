using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerLibrary
{
    public class Deck
    {
        //Create a deck of 52 cards
        public Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();

            foreach (Card.VALUE v in Enum.GetValues(typeof(Card.VALUE)))
            {
                foreach (Card.SUIT s in Enum.GetValues(typeof(Card.SUIT)))
                {
                    cards.Enqueue(new Card { MySuit = s, MyValue = v });
                }
            }
            return Shuffle(cards);
        }

        private static Queue<Card> Shuffle(Queue<Card> cards)
        {
            //Shuffle the existing cards using Fisher-Yates Modern
            List<Card> transformedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                //Randomly pick a card which has not been shuffled
                int k = r.Next(n + 1);

                //Swap the selected item 
                //with the last "unselected" card in the collection
                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Queue<Card> shuffledCards = new Queue<Card>();
            foreach (var card in transformedCards)
            {
                shuffledCards.Enqueue(card);
            }

            return shuffledCards;
        }

    }
}
