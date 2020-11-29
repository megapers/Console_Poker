using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class DrawCards
    {
        //Displays suit and value of the card 
        private void DrawCardSuitValue(Card card)
        {
            char cardSuit = ' ';
            string cardValue;
            
            Console.OutputEncoding = Encoding.UTF8;

            switch (card.MySuit)
            {
                case Card.SUIT.HEARTS:
                    cardSuit = '♥';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.DIAMONDS:
                    cardSuit = '♦';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Card.SUIT.CLUBS:
                    cardSuit = '♣';
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Card.SUIT.SPADES:
                    cardSuit = '♠';
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
            }

            switch (card.MyValue)
            {
                case Card.VALUE.JACK:
                    cardValue = "JACK";
                    break;
                case Card.VALUE.QUEEN:
                    cardValue = "QUEEN";
                    break;
                case Card.VALUE.KING:
                    cardValue = "KING";
                    break;
                case Card.VALUE.ACE:
                    cardValue = "ACE";
                    break;
                default:
                    cardValue = (int)card.MyValue + "";
                    break;
            }
            Console.Write(cardValue + cardSuit + "\t");
        }

        //Diaplay all players hands and winners
        public void DisplayCards(List<Player> players)
        {
            Console.Clear();
            int i = 0;
            bool winnersFound = false;
            foreach (var player in players)
            {
                if (!winnersFound && players.IndexOf(player) == 0)
                {
                    Console.WriteLine("***{0} is the WINNER!***", player.Name);
                }
                else if (players[i].CompareTo(players[i - 1]) == 0)
                {
                    Console.WriteLine("***{0} is the WINNER!***", player.Name);
                }
                else
                {
                    winnersFound = true;
                }
                Console.WriteLine("{0}'s HAND with {1}", player.Name, player.PlayerHand.Ranking.RankingTypes);
                foreach (var card in player.PlayerHand.Cards)
                {
                    DrawCardSuitValue(card);

                }
                Console.Write("\n\n");
               

                i++;
            }
        }

    }
}
