using Appodeal.Core.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Appodeal.Core.Factory
{
    public class GameCardFactory : IFactory<GameCardData, Transform, GameCard>
    {
        private readonly GameCardView _cardViewPrefab;
        private readonly DiContainer _container;
        private readonly CardSpritesSO _cardSpritesSO;

        public GameCardFactory(GameCardView cardViewPrefab, DiContainer container, CardSpritesSO cardSpritesSO)
        {
            _cardViewPrefab = cardViewPrefab;
            _container = container;
            _cardSpritesSO = cardSpritesSO;
        }
        
        public GameCard Create(GameCardData data, Transform parent)
        {
            var cardView = _container.InstantiatePrefabForComponent<GameCardView>(_cardViewPrefab, parent);
            cardView.CardImage.sprite = _cardSpritesSO.GetSprite(data.Suit, data.CardValue);
            
            var gameCard = _container.Instantiate<GameCard>();
            gameCard.Init(cardView, data);

            return gameCard;
        }
    }
}