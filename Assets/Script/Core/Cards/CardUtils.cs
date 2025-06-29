using System;

namespace Appodeal.Core
{
    public static class CardUtils
    {
        private static readonly CardSuit[] AllSuits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
        private static readonly CardValue[] AllValues = (CardValue[])Enum.GetValues(typeof(CardValue));
        private static readonly Random Random = new();

        public static GameCardData CreateRandomCard()
        {
            var suit = AllSuits[Random.Next(AllSuits.Length)];
            var value = AllValues[Random.Next(AllValues.Length)];
            return new GameCardData(suit, value);
        }
    }
}