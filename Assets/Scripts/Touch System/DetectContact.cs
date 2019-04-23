using System;
using System.Collections.Generic;
using UnityEngine;
using Ball;

namespace TouchSystem
{
    public class DetectContact : MonoBehaviour
    {
        Dictionary<int, Pair<Ball.Ball, Vector3>> balls = new Dictionary<int, Pair<Ball.Ball, Vector3>>(4);
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

        [SerializeField] float power = 5f; 


        #region CALLBACK
        //TODO: Try using a stack to allow you to influence the same ball with a different touch as long as the first touch is still being held down.
        private void HandleAddedPointer(object sender, EventArgs e)
        {
            if (e is PointerManagerEventArgs args)
            {
                int pointerID = args.PointerID;

                Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(PointerManager.GetPointerPosition(pointerID));
                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);
                if (hitInformation.collider != null && hitInformation.rigidbody.tag == "Ball")
                {
                    Ball.Ball ball = hitInformation.transform.GetComponent<Ball.Ball>();
                    ball.Freeze();

                    Pair<Ball.Ball, Vector3> pair = new Pair<Ball.Ball, Vector3>(ball, touchPosWorld2D);

                    balls.Add(pointerID, pair);
                }
            }
        }

        private void HandleRemovedPointer(object sender, EventArgs e)
        {
            if (e is PointerManagerEventArgs args)
            {
                int pointerID = args.PointerID;

                if(balls.ContainsKey(pointerID))
                {
                    Ball.Ball ball = balls[pointerID].First;
                    Vector3 start = balls[pointerID].Second;

                    Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(PointerManager.GetPointerPosition(pointerID));
                    Vector2 end = new Vector2(touchPosWorld.x, touchPosWorld.y);
                    
                    //delta = a - b
                    Vector3 delta = new Vector3(start.x - end.x, start.y - end.y);

                    ball.Launch(delta * power);
                    balls.Remove(pointerID);
                }
            }
        }

        #endregion CALLBACK
    }
}