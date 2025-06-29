using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Appodeal.Core.Clickable
{
    public class ClickableButton : MonoBehaviour, IBeginDragHandler, IPointerClickHandler, IPointerDownHandler
    {
        public event Action<PointerEventData> OnBeginDragAction;

        public void OnPointerDown(PointerEventData eventData)
        {
            
            Debug.LogError("OnPointerDown");
            //OnBeginDragAction?.Invoke(eventData);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.LogError("OnBeginDrag");
            OnBeginDragAction?.Invoke(eventData);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.LogError("OnPointerClick");
        }
    }
}