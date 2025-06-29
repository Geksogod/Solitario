namespace Appodeal.Core
{
    public class GameCardData
    {
        public CardSuit Suit { get; private set; }
        public CardValue CardValue { get; private set; }

        public GameCardData(CardSuit suit, CardValue value)
        {
            Suit = suit;
            CardValue = value;
        }
    }
}