using System;
using System.Collections.Generic;
using WarGame.Core;

namespace WarGame.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine("Enter number of players (2-4): ");
            int count = int.Parse(Console.ReadLine());

            List<string> players = new List<string>();

            for (int i = 1; i <= count; i++)
            {
                players.Add("Player " + i);
            }

            WarEngine game = new WarEngine(players);

        int maxRounds = 10000;

        for (int i = 1; i <= maxRounds; i++)
        {
            Console.WriteLine("Round " + i);

            string winner = game.PlayRound();

            Console.WriteLine();

            // Checks to see if game is over
            if (game.IsGameOver())
            {
                Console.WriteLine("Game Over!");
                Console.WriteLine("Winner: " + game.GetWinner());
                break;
            }

            // If we hit max rounds
            if (i == maxRounds)
            {
                Console.WriteLine("Reached round limit!");

                string winnerByCount = game.GetWinner();
                Console.WriteLine("Winner by most cards: " + winnerByCount);
                break; }    
            }                             
            //Note to self: Break is used for testing purposes, to prevent infinite loop in case of a very long game
        }
    }
}