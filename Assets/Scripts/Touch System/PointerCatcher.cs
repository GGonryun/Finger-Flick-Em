using UnityEngine;
using UnityEngine.EventSystems;

namespace TouchSystem {

	public enum PointerBeginMode {
		Never,
		OnPointerDown,
		OnDrag
	}

	/// <summary>
	/// Processes pointer clicks. (Place this behind all UI elements)
	/// </summary>
	public class PointerCatcher : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler {
		public PointerBeginMode beginMode = PointerBeginMode.OnPointerDown;

		#region INTERFACE
		public void OnPointerDown(PointerEventData eventData) {
			if (beginMode == PointerBeginMode.OnPointerDown)
				PointerManager.Add(eventData.pointerId);
		}

		public void OnPointerUp(PointerEventData eventData) {
			if (beginMode == PointerBeginMode.OnPointerDown)
				PointerManager.Remove(eventData.pointerId);
		}

		public void OnPointerClick(PointerEventData eventData) {
			PointerManager.Miss(eventData.pointerId);
		}

		public void OnDrag(PointerEventData eventData) {
		}

		public void OnBeginDrag(PointerEventData eventData) {
			if (beginMode == PointerBeginMode.OnDrag)
				PointerManager.Add(eventData.pointerId);
		}

		public void OnEndDrag(PointerEventData eventData) {
			if (beginMode == PointerBeginMode.OnDrag)
				PointerManager.Remove(eventData.pointerId);
		}
		#endregion INTERFACE
	}
}
