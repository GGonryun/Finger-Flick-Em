using UnityEngine;

namespace TouchSystem
{

    public class InvertedCursor : MonoBehaviour
    {
        public int PointerID
        {
            get
            {
                return pointerID;
            }
        }

        private Vector3 start;
        private int pointerID;

        public void Link(int pointerID)
        {
            this.pointerID = pointerID;
            this.start = PointerManager.GetPointerPosition(pointerID);
        }

        #region MONOBEHAVIOUR
        protected virtual void LateUpdate()
        {
            //When I click, mark origin => reflect about the origin.

            Vector3 end = PointerManager.GetPointerPosition(PointerID);
            //delta = a + a - b
            //Vector3 delta = new Vector3(start.x - end.x, start.y - end.x);
            //c = a + delta
            Vector3 pos = new Vector3(start.x + start.x - end.x, start.y + start.y - end.y);

            transform.position = pos;
        }
        #endregion MONOBEHAVIOUR
    }
}
