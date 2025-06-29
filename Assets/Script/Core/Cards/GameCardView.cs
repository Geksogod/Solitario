using Appodeal.Core.Clickable;
using UnityEngine;
using UnityEngine.UI;

namespace Appodeal.Core
{
    public class GameCardView : MonoBehaviour
    {
        [field: SerializeField] public Image CardImage { get; private set; }
        [field: SerializeField] public RectTransform CardViewTransform { get; private set; }
        [field: SerializeField] public HoldableButton CardButton { get; private set; }
    }
}