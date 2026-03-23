using System.Collections.Generic;

namespace WarGame.Core
{
    public class PlayedCards
    {
        public Dictionary<string, Card> Cards { get; private set; }

        public PlayedCards()
        {
            Cards = new Dictionary<string, Card>();
        }

        public void Add(string playerName, Card card)
        {
            Cards[playerName] = card;
        }

        public void Clear()
        {
            Cards.Clear();
        }
    }
}