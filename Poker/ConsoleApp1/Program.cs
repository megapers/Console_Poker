using System;
using System.Collections.Generic;
using System.Text;
using PokerLibrary;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new List<Player>
            {
                new Player{Name ="Tim"},
                new Player{Name ="Eugene"},
                new Player{Name ="Denise"},
                new Player{Name ="Maxine"},
                new Player{Name ="Viktor"}
            };

            var game = new PlayGame(players);

            Console.SetWindowSize(50, 30);
            // remove scroll bars by setting the buffer to the actual window size
            Console.BufferWidth = 50;
            Console.BufferHeight = 30;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Title = "Poker Game";
            bool quit = false;

            while (!quit)
            {
                game.Play();

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
