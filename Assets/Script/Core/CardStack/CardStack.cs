using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Appodeal.Core
{
    public class CardStack
    {
        [Inject] private IFactory<GameCardData, Transform, GameCard> _cardFactory;
        
        private readonly List<GameCard> _cardsList = new();
        public CardStackView CardStackView { get; private set; }

        public void Init(CardStackView cardStackView)
        {
            CardStackView = cardStackView;
        }

        public Vector3 GetCardMovePosition()
        {
            var lastItem = CardStackView.CardParent.GetChild(CardStackView.CardParent.childCount - 1).transform
                .position;
            return new Vector3(lastItem.x, lastItem.y - (Mathf.Abs(CardStackView.VerticalLayoutGroup.spacing)/2), lastItem.z);
        }

        public void AddRandomCard()
        {
            var randomCardData = CardUtils.CreateRandomCard();
            _cardFactory.Create(randomCardData, CardStackView.CardParent).SetStack(this);
        }

        public void RemoveCard(GameCard card)
        {
            _cardsList.Remove(card);
        }
    }
}