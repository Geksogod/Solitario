using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Appodeal.Core.Clickable
{
    public class HoldableButton : MonoBehaviour, IBeginDragHandler ,IDragHandler, IEndDragHandler
    {
        public event Action<PointerEventData> OnDragBeginAction;   
        public event Action<PointerEventData> OnDragAction;   
        public event Action<PointerEventData> OnDragEnd;

        public void OnDrag(PointerEventData eventData)
        {
            OnDragAction?.Invoke(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnDragEnd?.Invoke(eventData);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            OnDragBeginAction?.Invoke(eventData);
        }
    }
}