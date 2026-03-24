using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class WarEngine
    {
        private Deck deck;
        private PlayerHands playerHands;
        private PlayedCards playedCards;
        private List<Card> pot;

        public WarEngine(List<string> playerNames)
        {
            deck = new Deck();
            playerHands = new PlayerHands(playerNames);
            playedCards = new PlayedCards();
            pot = new List<Card>();

            DealCards(playerNames);
        }

        private void DealCards(List<string> playerNames)
        {
            int playerIndex = 0;

            List<string> names = playerNames;

            while (deck.Cards.Count > 0)
            {
                string currentPlayer = names[playerIndex];

                Card card = deck.Cards.Pop();
                playerHands.Hands[currentPlayer].AddCard(card);

                playerIndex++;

                if (playerIndex >= names.Count)
                {
                    playerIndex = 0;
                }
            }
        }
        public string PlayRound()
            {
                playedCards.Clear();

                // Each player plays one card
                foreach (var player in playerHands.Hands)
                {
                    if (player.Value.Count() == 0)
                        continue;

                    Card card = player.Value.PlayCard();
                    Console.WriteLine(player.Key + " plays: " + card);
                    
                    playedCards.Add(player.Key, card);
                    pot.Add(card);
                }

            // Find highest card
            string winner = "";
            int highestRank = 0;

            foreach (var entry in playedCards.Cards)
            {
                if (entry.Value.Rank > highestRank)
                {
                    highestRank = entry.Value.Rank;
                    winner = entry.Key;
                }
            }   

            // Give all pot cards to winner
            foreach (Card card in pot)
            {
                playerHands.Hands[winner].AddCard(card);
            }

            pot.Clear();

            return winner;
            }
            public bool IsGameOver()
            {
                int playersWithCards = 0;

                foreach (var player in playerHands.Hands)
                {
                    if (player.Value.Count() > 0)
                        playersWithCards++;
                }

                return playersWithCards <= 1;
            }

            public string GetWinner()
            {
                string winner = "";
                int maxCards = 0;

                foreach (var player in playerHands.Hands)
                {
                    int count = player.Value.Count();

                    if (count > maxCards)
                    {
                        maxCards = count;
                        winner = player.Key;
                    }
                }

                return winner;
            }
        }
    
}
