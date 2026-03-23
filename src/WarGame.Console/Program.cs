using System;
using System.Collections.Generic;
using WarGame.Core;

namespace WarGame.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> players = new List<string>
            {
                "Player 1",
                "Player 2"
            };

            WarEngine game = new WarEngine(players);

            for (int i = 1; i <= 10; i++)
            {
                string winner = game.PlayRound();
                System.Console.WriteLine($"Round {i} winner: {winner}");
            }
        }
    }
}