using System;
using System.Collections.Generic;
using WarGame.Core;

namespace WarGame.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== WAR CARD GAME ===");

            int count;
            while (true)
            {
                Console.Write("Enter number of players (2-4): ");
                if (int.TryParse(Console.ReadLine(), out count) && count >= 2 && count <= 4)
                    break;

                Console.WriteLine("Invalid input.");
            }

            List<string> players = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                Console.Write($"Enter name for Player {i}: ");
                string name = Console.ReadLine();
                players.Add(string.IsNullOrWhiteSpace(name) ? $"Player {i}" : name);
            }

            WarEngine game = new WarEngine(players);

            int round = 1;
            int maxRounds = 10000;

            while (!game.IsGameOver() && round <= maxRounds)
            {
                Console.WriteLine($"\n--- Round {round} ---");
                game.PlayRound();
                round++;
            }

            Console.WriteLine("\n=== GAME OVER ===");

            if (round > maxRounds)
                Console.WriteLine("Winner by most cards: " + game.GetWinner());
            else
                Console.WriteLine("Winner: " + game.GetWinner());
        }
    }
}