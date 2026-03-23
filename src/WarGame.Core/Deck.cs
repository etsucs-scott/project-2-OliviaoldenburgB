using System;
using System.Collections.Generic;

namespace WarGame.Core
{
    public class Deck
    {
        public Stack<Card> Cards { get; private set; }

        public Deck()
        {
            Cards = new Stack<Card>();
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
                    Cards.Push(new Card(suit, rank));
                }
            }
        }

        private void Shuffle()
        {
            List<Card> temp = new List<Card>(Cards);
            Cards.Clear();

            Random rand = new Random();

            while (temp.Count > 0)
            {
                int index = rand.Next(temp.Count);
                Cards.Push(temp[index]);
                temp.RemoveAt(index);
            }
        }
    } //This creates 52 card and shuffles them for the game. It uses a stack to hold the cards, which allows for easy drawing and discarding during the game.
}