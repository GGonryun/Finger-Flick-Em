using System;
using System.Collections.Generic;
using UnityEngine;

namespace TouchSystem.Debugging {

	public class CursorTester : MonoBehaviour {
		[SerializeField]
		private Cursor prefabCursor;
		[SerializeField]
		private Transform folder;
		private Dictionary<int, Cursor> cursors = new Dictionary<int, Cursor>();

		public AudioSource audioSource;

		#region MONOBEHAVIOUR
		protected virtual void OnEnable() {
			PointerManager.AddedPointer += HandleAddedPointer;
			PointerManager.RemovedPointer += HandleRemovedPointer;
			PointerManager.Missed += HandleMissed;
		}

		protected virtual void OnDisable() {
			PointerManager.AddedPointer -= HandleAddedPointer;
			PointerManager.RemovedPointer -= HandleRemovedPointer;
			PointerManager.Missed -= HandleMissed;
		}
		#endregion MONOBEHAVIOUR

		#region CALLBACK
		private void HandleAddedPointer(object sender, EventArgs e) {
			if (e is PointerManagerEventArgs args) {
				int pointerID = args.PointerID;

				Cursor cursor = Instantiate(prefabCursor, folder);
				cursor.Link(pointerID);

				cursors.Add(pointerID, cursor);

				audioSource.Play();
				AudioSource.PlayClipAtPoint(audioSource.clip, Vector3.zero, 1.0F);
			}
		}

		private void HandleRemovedPointer(object sender, EventArgs e) {
			if (e is PointerManagerEventArgs args) {
				int pointerID = args.PointerID;

				Cursor cursor = cursors[pointerID];
				cursors.Remove(pointerID);

				Destroy(cursor.gameObject);

			}
		}

		private void HandleMissed(object sender, EventArgs e) {
			if (e is PointerManagerEventArgs args) {
			}
		}
		#endregion CALLBACK
	}
}
