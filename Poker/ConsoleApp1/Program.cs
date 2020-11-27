using System;
using System.Text;
using PokerLibrary;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BufferWidth = 65;
            Console.BufferHeight = 40;

            var card = new Card {MySuit = Card.SUIT.DIAMONDS, MyValue = Card.VALUE.QUEEN };

            //DrawCards.PrintCard(card);
            DrawCards.DrawCardSuitValue(card, 0, 0);

           
        }
    }
}
