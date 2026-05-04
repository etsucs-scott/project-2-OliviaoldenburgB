using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class Hand
    {
        private Queue<Card> cards;

        public Hand()
        {
            cards = new Queue<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Enqueue(card);
        }

        public void AddCards(IEnumerable<Card> newCards)
        {
            foreach (var card in newCards)
            {
                cards.Enqueue(card);
            }
        }

        public Card PlayCard()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("No cards left.");

            return cards.Dequeue();
        }

        public int Count => cards.Count;
    }
}