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

            var card = new Card {MySuit = Card.SUIT.CLUBS, MyValue = Card.VALUE.ACE };

            DrawCards.DrawCardOutline(0, 0);
            DrawCards.DrawCardSuitValue(card, 0, 0);

           
        }
    }
}
