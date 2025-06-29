using UnityEngine;
using UnityEngine.EventSystems;

namespace Appodeal.Core.CardAction.CardMove
{
    public class MoveCardData : ICardActionData
    { 
        public CardStack OldStack { get; set; }
        public CardStack NewStack { get; set; }
        public GameCard GameCard { get; set; }
    }
}