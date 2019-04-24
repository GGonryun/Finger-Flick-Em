using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{

    public class Eraser : MonoBehaviour
    {
        [SerializeField] BoxCollider2D eraserField = null;
        [SerializeField] float slack = 1.4f;
        [SerializeField] new string tag = "Ball";

        public void SetZone()
        {
            eraserField.offset = Vector2.zero;
            eraserField.size = new Vector2(ScreenManager.Width * slack, ScreenManager.Height * slack);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == tag)
            {
                collision.GetComponent<Ball>().Reclaim();
            }
        }
    }

}
