using System.Collections.Generic;
using Appodeal.Core.CardAction.CardMove;
using Appodeal.Core.Signal;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Appodeal.Core
{
    public class BoardManager : MonoBehaviour
    {
        [Inject] private SignalBus _signalBus;
        [Inject] private IFactory<Transform, CardStack> _stackFactory;
        
        [Header("Scene setup")]
        [SerializeField] private RectTransform _cardStackViewParent;
        [SerializeField] private Button _undoButton;
        
        [Header("Game setup")]
        [SerializeField] private int _stackCount;

        public readonly List<CardStack> _cardStacks = new(4);
        private readonly Stack<MoveCard> _moveStack = new ();
        
        private void Start()
        {
            for (var i = 0; i < _stackCount; i++)
            {
                var cardStack = _stackFactory.Create(_cardStackViewParent);
                cardStack.AddRandomCard();
                _cardStacks.Add(cardStack);
            }
            
            _signalBus.Subscribe<OnCardGameClickSignal>(OnCardMove);
            _undoButton.onClick.AddListener(UndoMove);
            _undoButton.interactable = false;
        }

        private void UndoMove()
        {
            if (_moveStack.Count <= 0)
            {
                return;
            }
            
            _moveStack.Pop().Undo();
            
            _undoButton.interactable = _moveStack.Count > 0;
        }

        private void OnCardMove(OnCardGameClickSignal signal)
        {
            var newMoveActionData = new MoveCardData()
            {
                GameCard = signal.GameCard,
                OldStack = signal.OldStack,
                NewStack = signal.NewStack
            };

            var newMoveAction = new MoveCard
            {
                Data = newMoveActionData
            };
            
            newMoveAction.Precess();
            _moveStack.Push(newMoveAction);
            _undoButton.interactable = true;
        }
        
    }
}