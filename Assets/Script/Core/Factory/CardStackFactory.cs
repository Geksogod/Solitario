using UnityEngine;
using Zenject;

namespace Appodeal.Core.Factory
{
    public class CardStackFactory : IFactory<Transform, CardStack>
    {
        private readonly CardStackView _stackViewPrefab;
        private readonly DiContainer _container;

        public CardStackFactory(CardStackView stackViewPrefab, DiContainer container)
        {
            _stackViewPrefab = stackViewPrefab;
            _container = container;
        }

        public CardStack Create(Transform parent)
        {
            var stackView = _container.InstantiatePrefabForComponent<CardStackView>(_stackViewPrefab, parent);
            var cardStack = _container.Instantiate<CardStack>();
            stackView.Init(cardStack);
            cardStack.Init(stackView);

            return cardStack;
        }
    }
}