using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class DeckOfCards: Card
    {
        private const int NUM_OF_CARDS = 52;
        private const int NUM_OF_CARD_VALS = 13;
        private Card[] deck = new Card[NUM_OF_CARDS];

        

        public Card[] getDeck { get { return deck; } } //get current deck

        //Initialize a deck
        public void setUpDeck()
        {
            int i = 0;

            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card {MySuit = s, MyValue = v};
                    i++;
                }
            }
            shuffleDeck();//shuffle the deck after it's initialized
        }

        //Shuffle the deck
        private void shuffleDeck()
        {
            var rand = new Random();
            Card temp;

            //shuffle 100 times
            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < NUM_OF_CARDS; j++)
                {
                    //swap the cards
                    int randCardNum = rand.Next(NUM_OF_CARD_VALS);
                    temp = deck[j];
                    deck[j] = deck[randCardNum];
                    deck[randCardNum] = temp;
                }
            }
        }
    }
}
