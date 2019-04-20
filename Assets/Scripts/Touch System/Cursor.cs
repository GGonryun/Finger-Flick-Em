using UnityEngine;

namespace TouchSystem {

	public class Cursor : MonoBehaviour {
		public int PointerID {
			get {
				return pointerID;
			}
		}

		private int pointerID;

		public void Link(int pointerID) {
			this.pointerID = pointerID;
		}

		#region MONOBEHAVIOUR
		protected virtual void LateUpdate() {
			transform.position = PointerManager.GetPointerPosition(PointerID);
		}
		#endregion MONOBEHAVIOUR
	}
}
