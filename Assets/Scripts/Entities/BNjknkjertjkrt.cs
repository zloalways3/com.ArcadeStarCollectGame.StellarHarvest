using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Entities
{
    public class BNjknkjertjkrt : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private RectTransform borders;
        
        public event Action<Obj> OnTrigger;

        public bool IsStopped { get; set; }

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (IsStopped)
                return;

            Vector2 position = new Vector2(
                2f * borders.rect.xMax * (eventData.position.x - Screen.width * 0.5f) / Screen.width,
                (2f * borders.rect.yMax - borders.sizeDelta.y) * (eventData.position.y - Screen.height * 0.5f) / Screen.height - borders.sizeDelta.y / 2f
            );
            Debug.Log(position);
            // Debug.Log();
            
            rectTransform.anchoredPosition = new Vector2(
                Math.Min(Math.Max(position.x, borders.rect.xMin + rectTransform.sizeDelta.x / 2f), borders.rect.xMax - rectTransform.sizeDelta.x / 2f),
                Math.Min(Math.Max(position.y, borders.rect.yMin + rectTransform.sizeDelta.y / 2f), borders.rect.yMax - rectTransform.sizeDelta.y / 2f)
            );
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTrigger.Invoke(other.GetComponent<Obj>());
        }
    }
}