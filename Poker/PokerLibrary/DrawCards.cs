using System;
using System.Collections.Generic;
using System.Text;

namespace PokerLibrary
{
    public class DrawCards
    {
        //displays suit and value of the card inside its outline
        public static void DrawCardSuitValue(Card card, int xcoor, int ycoor)
        {
            char cardSuit = ' ';
            int x = xcoor * 12;
            int y = ycoor;
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;

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

        public static void DrawCardSuitValue1(Card card)
        {
            char cardSuit = ' ';
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.White;


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

            Console.Write(card.MyValue + " " + cardSuit + "  ");

           
        }

        //private static void PrintMethod(Card card)
        //{
        //    bool hasWrittenFirstNumber = false;

        //    switch (card.MySuit)
        //    {
        //        case Card.SUIT.HEARTS:
        //        case Card.SUIT.DIAMONDS:
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            break;
        //        case Card.SUIT.CLUBS:
        //        case Card.SUIT.SPADES:
        //            Console.ForegroundColor = ConsoleColor.Black;
        //            break;
        //    }

        //    for (int i = 0; i < _printString.Length; i++)
        //    {
        //        Console.BackgroundColor = ConsoleColor.White;
        //        if (i % 11 == 0 && i != 0)
        //        {
        //            Console.CursorLeft -= 11;
        //            Console.CursorTop += 1;
        //        }
        //        if (_printString[i] == 'S')
        //        {
        //            switch (card.MySuit)
        //            {
        //                case Card.SUIT.HEARTS:
        //                    Console.Write('♥');
        //                    break;
        //                case Card.SUIT.CLUBS:
        //                    Console.Write("♣");
        //                    break;
        //                case Card.SUIT.DIAMONDS:
        //                    Console.Write("♦");
        //                    break;
        //                case Card.SUIT.SPADES:
        //                    Console.Write("♠");
        //                    break;
        //            }
        //            continue;
        //        }
        //        else if (_printString[i] == 'V')
        //        {
        //            if (card.MyValue == Card.VALUE.TEN)//??????
        //            {
        //                if (hasWrittenFirstNumber == false)
        //                {
        //                    Console.Write(10);
        //                    hasWrittenFirstNumber = true;
        //                    i++;
        //                }
        //                else
        //                {
        //                    Console.CursorLeft--;
        //                    Console.Write(10);
        //                }
        //                continue;
        //            }
        //            else if (card.MyValue == Card.VALUE.JACK)
        //            {
        //                Console.Write("J");
        //            }
        //            else if (card.MyValue == Card.VALUE.QUEEN)
        //            {
        //                Console.Write("Q");
        //            }
        //            else if (card.MyValue == Card.VALUE.KING)
        //            {
        //                Console.Write("K");
        //            }
        //            else if (card.MyValue == Card.VALUE.ACE)
        //            {
        //                Console.Write("A");
        //            }
        //            else
        //            {
        //                Console.Write((int)card.MyValue);
        //            }
        //        }
        //        else
        //        {
        //            Console.Write(_printString[i]);
        //        }
        //   }
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = ConsoleColor.White;
       // }
    }
}
