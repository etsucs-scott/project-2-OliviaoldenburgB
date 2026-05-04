using System;
using System.Collections.Generic;
using System.Linq;

namespace WarGame.Core
{
    public class WarEngine
    {
        private Deck deck;
        private PlayerHands playerHands;
        private List<Card> pot;

        public WarEngine(List<string> playerNames)
        {
            deck = new Deck();
            playerHands = new PlayerHands(playerNames);
            pot = new List<Card>();

            DealCards(playerNames);
        }

        private void DealCards(List<string> players)
        {
            int index = 0;

            while (deck.Count > 0)
            {
                var player = players[index];
                playerHands.GetHand(player).AddCard(deck.Draw());

                index = (index + 1) % players.Count;
            }
        }

        public void PlayRound()
        {
            ResolveBattle(playerHands.GetPlayers().ToList());
        }

        private string ResolveBattle(List<string> players)
        {
            Dictionary<string, Card> round = new Dictionary<string, Card>();

            foreach (var player in players)
            {
                var hand = playerHands.GetHand(player);

                if (hand.Count == 0) continue;

                var card = hand.PlayCard();
                Console.WriteLine($"{player} plays {card}");

                round[player] = card;
                pot.Add(card);
            }

            int highest = round.Values.Max(c => c.Rank);

            var winners = round
                .Where(x => x.Value.Rank == highest)
                .Select(x => x.Key)
                .ToList();

            if (winners.Count == 1)
            {
                var winner = winners[0];
                Console.WriteLine($"Winner: {winner}");

                playerHands.GetHand(winner).AddCards(pot);
                pot.Clear();

                return winner;
            }

            Console.WriteLine("WAR!");

            List<string> warPlayers = new List<string>();

            foreach (var player in winners)
            {
                var hand = playerHands.GetHand(player);

                if (hand.Count < 2)
                {
                    Console.WriteLine($"{player} eliminated (not enough cards)");
                    continue;
                }

                pot.Add(hand.PlayCard()); // face-down
                warPlayers.Add(player);
            }

            if (warPlayers.Count == 1)
            {
                var winner = warPlayers[0];
                playerHands.GetHand(winner).AddCards(pot);
                pot.Clear();
                return winner;
            }

            return ResolveBattle(warPlayers);
        }

        public bool IsGameOver()
        {
            int active = playerHands
                .GetPlayers()
                .Count(p => playerHands.GetHand(p).Count > 0);

            return active <= 1;
        }

        public string GetWinner()
        {
            return playerHands
                .GetPlayers()
                .OrderByDescending(p => playerHands.GetHand(p).Count)
                .First();
        }
    }
}