using System;
using System.Collections.Generic;
using UnityEngine;

namespace TouchSystem.Debugging
{

    public class InvertedCursorTester : MonoBehaviour
    {
        [SerializeField]
        private InvertedCursor prefabCursor = null;
        [SerializeField]
        private Transform folder = null;
        private Dictionary<int, InvertedCursor> cursors = new Dictionary<int, InvertedCursor>();

        public AudioSource audioSource;

        #region MONOBEHAVIOUR
        protected virtual void OnEnable()
        {
            PointerManager.AddedPointer += HandleAddedPointer;
            PointerManager.RemovedPointer += HandleRemovedPointer;
        }

        protected virtual void OnDisable()
        {
            PointerManager.AddedPointer -= HandleAddedPointer;
            PointerManager.RemovedPointer -= HandleRemovedPointer;
        }
        #endregion MONOBEHAVIOUR

        #region CALLBACK
        private void HandleAddedPointer(object sender, EventArgs e)
        {
            if (e is PointerManagerEventArgs args)
            {
                int pointerID = args.PointerID;

                InvertedCursor cursor = Instantiate(prefabCursor, folder);
                cursor.Link(pointerID);

                cursors.Add(pointerID, cursor);

                audioSource.Play();
                AudioSource.PlayClipAtPoint(audioSource.clip, Vector3.zero, 1.0F);
            }
        }

        private void HandleRemovedPointer(object sender, EventArgs e)
        {
            if (e is PointerManagerEventArgs args)
            {
                int pointerID = args.PointerID;

                InvertedCursor cursor = cursors[pointerID];
                cursors.Remove(pointerID);

                Destroy(cursor.gameObject);

            }
        }
        #endregion CALLBACK
    }
}
