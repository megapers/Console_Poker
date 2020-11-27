using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerLibrary
{
    public class DealQueueCards
    {

        private Player[] _players;
        private QueueDeck queueDeck = new QueueDeck();
        private Queue<Card> deck;
        public DealQueueCards(Player[] players)
        {
            _players = players;
            //Throw exception if number of players is 2 < and > 7
        }

        public void Deal()
        {
            deck = queueDeck.CreateCards();
            getHand();
            displayCards();
        }

        public void getHand()
        {
            //add logic to calculate right amount of cards in the deck based on number of players

            int count = 0;
            foreach(var player in _players)
            {
                for(int i = 0; i < player.Hand.Length; i++)
                {
                    player.Hand[i] = deck.Dequeue();
                }

                //sorting each hand by value
                _players[count].Hand = player.Hand.OrderBy(h => h.MyValue).ToArray();
                count++;
            }
        }


        public void displayCards()
        {
            Console.Clear();
            int x = 0; //x position of the cursor. We move it left and right
            int y = 1;//y position of the cursor, we move up and down

            foreach(var player in _players)
            {
                Console.WriteLine("{0}'s HAND", player.Name);
                foreach(var hand in player.Hand)
                {
                    DrawCards.DrawCardSuitValue(hand, x, y);
                    x++;//move to the right
                }
                y += 14;
                x = 0; 
                Console.SetCursorPosition(x, y);
            }


        }



    }
}
