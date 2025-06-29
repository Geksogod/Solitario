using System.Collections.Generic;
using Appodeal.Core.Signal;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Appodeal.Core
{
    public class GameCard
    {
        [Inject] private Canvas  _canvas;
        [Inject] private SignalBus  _signalBus;

        public GameCardView CardView => _cardView;
        
        private GameCardView _cardView;
        private GameCardData _data;
        private Vector2 _dragOffset;
        private CardStack _currentStack;
        
        public void Init(GameCardView cardView, GameCardData data)
        {
            _cardView = cardView;
            _data = data;
            _cardView.CardButton.OnDragBeginAction += CardButtonOnOnBeginDragAction;
            _cardView.CardButton.OnDragAction += Drag;
            _cardView.CardButton.OnDragEnd += OnDragEnd;
        }

        public void SetStack(CardStack stack)
        {
            _currentStack = stack;
        }

        private void OnDragEnd(PointerEventData obj)
        {
            _cardView.CardViewTransform.SetParent(_cardView.transform);
            
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(obj, results);

            foreach (var result in results)
            {
                if (result.gameObject == _cardView.CardViewTransform.gameObject)
                    continue; 
                
                var stackView = result.gameObject.GetComponentInParent<CardStackView>();
                if (stackView)
                {
                    var moveSignal = new OnCardGameClickSignal()
                    {
                        OldStack = _currentStack,
                        GameCard = this,
                        NewStack = stackView.CardStack
                    };
                    _signalBus.Fire(moveSignal);
                    return;
                }
            }

            _cardView.CardViewTransform.transform.DOLocalMove(Vector3.zero, 0.2f);
        }

        private void CardButtonOnOnBeginDragAction(PointerEventData obj)
        {
            _cardView.CardViewTransform.SetParent(_canvas.transform);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                obj.position,
                _canvas.worldCamera,
                out var localPointerPosition);
            _dragOffset = _cardView.CardViewTransform.anchoredPosition - localPointerPosition;
        }
        
        private void Drag(PointerEventData  eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                eventData.position,
                _canvas.worldCamera,
                out var localPointerPosition);

            _cardView.CardViewTransform.anchoredPosition = localPointerPosition + _dragOffset;
        }
    }
}