using UnityEngine;
using UnityEngine.EventSystems;

namespace Appodeal.Core.Signal
{
    public class OnCardGameClickSignal
    {
        public GameCard GameCard { get; set; }
        public CardStack OldStack { get; set; }
        public CardStack NewStack { get; set; }
    }
}