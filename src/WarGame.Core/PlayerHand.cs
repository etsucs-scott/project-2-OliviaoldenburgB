using System.Collections.Generic;

namespace WarGame.Core
{
    public class PlayerHands
    {
        private Dictionary<string, Hand> hands;

        public PlayerHands(List<string> playerNames)
        {
            hands = new Dictionary<string, Hand>();

            foreach (var name in playerNames)
            {
                hands[name] = new Hand();
            }
        }

        public Hand GetHand(string player)
        {
            return hands[player];
        }

        public IEnumerable<string> GetPlayers()
        {
            return hands.Keys;
        }
    }
}