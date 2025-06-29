using System.Collections.Generic;
using UnityEngine;

namespace Appodeal.Core.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Solitaire/CardSpritesSO")]
    public class CardSpritesSO : ScriptableObject
    {
        [SerializeField] private List<CardSpriteData> _cardSprites = new();
        private readonly Dictionary<(CardSuit, CardValue), Sprite> _lookup = new();
        

        public Sprite GetSprite(CardSuit suit, CardValue value)
        {
            if (_lookup.Count == 0)
            {
                foreach (var item in _cardSprites)
                    _lookup[(item.Suit, item.Value)] = item.Sprite;
            }
            _lookup.TryGetValue((suit, value), out var sprite);
            return sprite;
        }
    }
    [System.Serializable]
    internal class CardSpriteData
    {
        public CardSuit Suit;
        public CardValue Value;
        public Sprite Sprite;
    }
}