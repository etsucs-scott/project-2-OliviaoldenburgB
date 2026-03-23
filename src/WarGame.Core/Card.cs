namespace WarGame.Core
{
    public class Card
    {
        public string Suit { get; }
        public int Rank { get; }

        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            string rankName;

            if (Rank == 11) rankName = "J";
            else if (Rank == 12) rankName = "Q";
            else if (Rank == 13) rankName = "K";
            else if (Rank == 14) rankName = "A";
            else rankName = Rank.ToString();

            return rankName + " of " + Suit;
        }//this creates the suits for the cards and assigns the correct name to the rank of the card
    }
}