using System;
using System.Text;
using PokerLibrary;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var players = new Player[]
            {
                new Player{Name ="Atanarjuat"},
                new Player{Name ="Bibigul"}

            };

            var dc = new DealQueueCards(players);


            Console.SetWindowSize(65, 40);
            // remove scroll bars by setting the buffer to the actual window size
            Console.BufferWidth = 65;
            Console.BufferHeight = 40;
            Console.Title = "Poker Game";
            bool quit = false;

            while (!quit)
            {
                dc.Deal();

                char selection = ' ';
                while (!selection.Equals('Y') && !selection.Equals('N'))
                {
                    Console.WriteLine("Play again? Y-N");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (selection.Equals('Y'))
                        quit = false;
                    else if (selection.Equals('N'))
                        quit = true;
                    else
                        Console.WriteLine("Invalid Selection. Try again");
                }
            }

            Console.ReadKey();


        }
    }
}
