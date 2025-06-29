using UnityEngine;
using UnityEngine.UI;

namespace Appodeal.Core
{
    public class CardStackView : MonoBehaviour
    {
        public CardStack CardStack { get; private set; }

        [field: SerializeField] public RectTransform CardParent { get; private set; }
        [field: SerializeField] public VerticalLayoutGroup VerticalLayoutGroup { get; private set; }

        public void Init(CardStack cardStack)
        {
            CardStack = cardStack;
        }
    }
}