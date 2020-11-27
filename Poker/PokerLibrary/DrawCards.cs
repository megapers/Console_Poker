using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class DrawCards
    {
        //draw cards outlines
        public static void DrawCardOutline(int xcoor, int ycoor)
        {
            Console.BackgroundColor = ConsoleColor.White;

            int x = xcoor * 12;
            int y = ycoor;

            Console.SetCursorPosition(x, y);
            Console.Write(" __________\n"); //top edge of the card

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);

                if (i != 9)
                    Console.WriteLine("|          |");//left and right edges of the card
                else
                    Console.WriteLine("|__________|");//bottom edge of the card
            }
        }

        //displays suit and value of the card inside its outline
        public static void DrawCardSuitValue(Card card, int xcoor, int ycoor)
        {
            char cardSuit = ' ';
            int x = xcoor * 12;
            int y = ycoor;
            Console.OutputEncoding = Encoding.UTF8;
            //Encode each byte array from the CodePage437 into a character
            //hears and diamonds are red, clubs and spades are black
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

            //display the encoded character and value of the card
            Console.SetCursorPosition(x + 5, y + 5);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.MyValue);

        }
    }
}
