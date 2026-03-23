using System.Collections.Generic;

namespace WarGame.Core
{
    public class Hand
    {
        public Queue<Card> Cards { get; private set; }

        public Hand()
        {
            Cards = new Queue<Card>();
        }

        // Add a card to the hand
        public void AddCard(Card card)
        {
            Cards.Enqueue(card);
        }

        // Play the top card
        public Card PlayCard()
        {
            return Cards.Dequeue();
        }

        // Number of cards in hand
        public int Count()
        {
            return Cards.Count;
        }
    }
}