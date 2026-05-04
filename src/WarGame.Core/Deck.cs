using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class Deck
    {
        private static Random rand = new Random();

        private Stack<Card> cards;

        public Deck()
        {
            cards = new Stack<Card>();
            CreateDeck();
            Shuffle();
        }

        private void CreateDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

            for (int rank = 2; rank <= 14; rank++)
            {
                foreach (string suit in suits)
                {
                    cards.Push(new Card(suit, rank));
                }
            }
        }

        private void Shuffle()
        {
            List<Card> temp = new List<Card>(cards);
            cards.Clear();

            while (temp.Count > 0)
            {
                int index = rand.Next(temp.Count);
                cards.Push(temp[index]);
                temp.RemoveAt(index);
            }
        }

        public Card Draw()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("Deck is empty.");

            return cards.Pop();
        }

        public int Count => cards.Count;
    }
}