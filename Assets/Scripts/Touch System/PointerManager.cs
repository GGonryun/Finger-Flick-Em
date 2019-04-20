using System;
using System.Collections.Generic;
using UnityEngine;

namespace TouchSystem
{
    public class PointerManagerEventArgs : EventArgs
    {
        public int PointerID
        {
            get
            {
                return pointerID;
            }
        }

        private readonly int pointerID;

        public PointerManagerEventArgs(int pointerID)
        {
            this.pointerID = pointerID;
        }
    }

    public class PointerManager : Singleton<PointerManager>
    {
        public static int PointerCount
        {
            get
            {
                return Current.pointerIDs.Count;
            }
        }

        private HashSet<int> pointerIDs = new HashSet<int>();

        public static void Add(int pointerID)
        {
            Current.pointerIDs.Add(pointerID);

            PointerManagerEventArgs args = new PointerManagerEventArgs(pointerID);
            OnAddPointer(args);
        }

        public static void Remove(int pointerID)
        {
            Current.pointerIDs.Remove(pointerID);

            PointerManagerEventArgs args = new PointerManagerEventArgs(pointerID);
            OnRemovePointer(args);
        }

        public static void Miss(int pointerID)
        {
            PointerManagerEventArgs args = new PointerManagerEventArgs(pointerID);
            OnMiss(args);
        }

        public static Vector3 GetPointerPosition(int pointerID)
        {
            if (pointerID < 0)
                return Input.mousePosition;

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.fingerId == pointerID)
                    return touch.position;
            }

            throw new KeyNotFoundException();
        }

        #region EVENT
        public static event EventHandler AddedPointer
        {
            add
            {
                Current.addedPointer += value;
            }
            remove
            {
                Current.addedPointer -= value;
            }
        }
        public static event EventHandler RemovedPointer
        {
            add
            {
                Current.removedPointer += value;
            }
            remove
            {
                Current.removedPointer -= value;
            }
        }
        public static event EventHandler Missed
        {
            add
            {
                Current.missed += value;
            }
            remove
            {
                Current.missed -= value;
            }
        }

        private event EventHandler addedPointer;
        private event EventHandler removedPointer;
        private event EventHandler missed;

        protected static void OnAddPointer(EventArgs e)
        {
            if (Current.addedPointer != null)
                Current.addedPointer(Current, e);
        }

        protected static void OnRemovePointer(EventArgs e)
        {
            if (Current.removedPointer != null)
                Current.removedPointer(Current, e);
        }

        protected static void OnMiss(EventArgs e)
        {
            if (Current.missed != null)
                Current.missed(Current, e);
        }
        #endregion EVENT
    }
}
