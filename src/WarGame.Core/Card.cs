using System;

namespace WarGame.Core
{
    public class Card
    {
        public string Suit { get; }
        public int Rank { get; }

        public Card(string suit, int rank)
        {
            if (rank < 2 || rank > 14)
                throw new ArgumentException("Rank must be between 2 and 14.");

            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            string rankName = Rank switch
            {
                11 => "J",
                12 => "Q",
                13 => "K",
                14 => "A",
                _ => Rank.ToString()
            };

            return $"{rankName} of {Suit}";
        }
    }
}