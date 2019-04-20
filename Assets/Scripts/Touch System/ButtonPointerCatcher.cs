using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TouchSystem {

	/// <summary>
	/// Processes pointer clicks on UI elements. (Place this on buttons, labels, etc.)
	/// </summary>
	public class ButtonPointerCatcher : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {
		public PointerBeginMode beginMode;
		public UnityEvent onClick;
        public UnityEvent onRelease;

        #region INTERFACE
        public void OnPointerDown(PointerEventData eventData)
        {
            if (beginMode == PointerBeginMode.OnPointerDown)
            {
                PointerManager.Add(eventData.pointerId);
                OnPointerClick(eventData);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (beginMode == PointerBeginMode.OnPointerDown)
            {
                PointerManager.Remove(eventData.pointerId);
                OnPointerRelease(eventData);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (beginMode == PointerBeginMode.OnDrag)
                PointerManager.Add(eventData.pointerId);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (beginMode == PointerBeginMode.OnDrag)
                PointerManager.Remove(eventData.pointerId);
        }

        public void OnPointerClick(PointerEventData eventData) {
			onClick.Invoke();
		}

        public void OnPointerRelease(PointerEventData eventData)
        {
            onRelease.Invoke();
        }
        #endregion INTERFACE
    }
}
