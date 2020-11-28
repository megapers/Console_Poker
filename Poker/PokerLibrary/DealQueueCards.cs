using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokerLibrary
{
    public class DealQueueCards
    {
        public static readonly int HANDSIZE = 5;
        private List<Player> _players;
        private QueueDeck queueDeck = new QueueDeck();
        private Queue<Card> deck;
        public DealQueueCards(List<Player> players)
        {
            _players = players;
            //Throw exception if number of players is 2 < and > 7
        }

        public void Deal()
        {
            deck = queueDeck.CreateCards();
            getHand();
            evaluateHands();
            displayCards1();
            resetPlayers();
        }

        public void getHand()
        {
            //add logic to calculate right amount of cards in the deck based on number of players
            //deal one card to each player at a time
            //Make hand size
            int count = 0;

            for(int i = 0; i < HANDSIZE; i++)
            {

                foreach(var player in _players)
                {
                    player.PlayerHand[i] = deck.Dequeue();

                }
                //sorting each hand by value
                //
                //count++;
            }
            foreach (var player in _players)
            {
                player.PlayerHand = player.PlayerHand.OrderBy(h => h.MyValue).ToArray();
              
            }
            //var test = _players.ToList();
            //test.ForEach(p => 
            //    { p.Hand = p.Hand.OrderBy(h => h.MyValue).ToArray(); 
            //}) ;
            //_players = test.ToArray();
        }



        public void evaluateHands()
        {

            foreach (var player in _players)
            {
                new HandEvaluator(player).EvaluateHand();
            }

            _players.Sort();
          

           

            //var test = dict.OrderBy(p => p.Value);
            Console.WriteLine();


            ////get the player;s and computer's hand
            //Hand playerHand = playerHandEvaluator.EvaluateHand();
            //Hand computerHand = computerHandEvaluator.EvaluateHand();



            ////display each hand
            //Console.WriteLine("\n\n\n\n\nPlayer's Hand: " + playerHand);
            //Console.WriteLine("\nComputer's Hand: " + computerHand);

            ////evaluate hands
            //if (playerHand > computerHand)
            //{
            //    Console.WriteLine("Player WINS!");
            //}
            //else if (playerHand < computerHand)
            //{
            //    Console.WriteLine("Computer WINS!");
            //}
            //else //if the hands are the same, evaluate the values
            //{
            //    //first evaluate who has higher value of poker hand
            //    if (playerHandEvaluator.HandValues.Total > computerHandEvaluator.HandValues.Total)
            //        Console.WriteLine("Player WINS!");
            //    else if (playerHandEvaluator.HandValues.Total < computerHandEvaluator.HandValues.Total)
            //        Console.WriteLine("Computer WINS!");
            //    //if both hanve the same poker hand (for example, both have a pair of queens), 
            //    //than the player with the next higher card wins
            //    else if (playerHandEvaluator.HandValues.HighCard > computerHandEvaluator.HandValues.HighCard)
            //        Console.WriteLine("Player WINS!");
            //    else if (playerHandEvaluator.HandValues.HighCard < computerHandEvaluator.HandValues.HighCard)
            //        Console.WriteLine("Computer WINS!");
            //    else
            //        Console.WriteLine("DRAW, no one wins!");
            //}
        }

        public void displayCards1()
        {
            Console.Clear();
            int i = 0;
            bool winnersFound = false;
            foreach (var player in _players)
            {
                if(!winnersFound &&_players.IndexOf(player) == 0)
                {
                    Console.WriteLine("{0} is the WINNER!", player.Name);
                }
                else if(_players[i].CompareTo(_players[i-1]) == 0)
                {
                    Console.WriteLine("{0} is the WINNER!", player.Name);
                }
                else 
                {
                    winnersFound = true;
                }
                Console.WriteLine("{0}'s HAND with {1}", player.Name, player.handValue.handRanking);
                foreach (var card in player.PlayerHand)
                {
                    DrawCards.DrawCardSuitValue1(card);

                }
                Console.WriteLine();
                i++;
            }

        }

        public void resetPlayers()
        {
            foreach(var player in _players)
            {
                player.handValue.Total = 0;
            }
        }

    }
}
