using DG.Tweening;
using UnityEngine;

namespace Appodeal.Core.CardAction.CardMove
{
    public class MoveCard : ICardAction<MoveCardData>
    {
        public MoveCardData Data { get; set; }
        
        public void Precess()
        {
            MoveTo(Data.NewStack);
        }

        public void Undo()
        {
            MoveTo(Data.OldStack);
        }

        private void MoveTo(CardStack stack)
        {
            if (stack == null)
            {
                return;
            }
            
            Data.GameCard.CardView.CardViewTransform.DOMove(stack.GetCardMovePosition(), 0.2f).OnComplete(() =>
            {
                Data.GameCard.CardView.transform.SetParent(stack.CardStackView.CardParent);
                Data.GameCard.CardView.CardViewTransform.localPosition = Vector3.zero;
                Data.GameCard.SetStack(stack);
            });
        }
    }
}