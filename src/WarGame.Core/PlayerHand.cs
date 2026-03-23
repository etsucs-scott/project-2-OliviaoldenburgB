using System.Collections.Generic;

namespace WarGame.Core
{
    public class PlayerHands
    {
        public Dictionary<string, Hand> Hands { get; private set; }

        public PlayerHands(List<string> playerNames)
        {
            Hands = new Dictionary<string, Hand>();

            foreach (string name in playerNames)
            {
                Hands[name] = new Hand();
            }
        }
    }
}