using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] Vector3 launchPoint = Vector3.zero;
        [SerializeField] Vector2 velocity = Vector2.up;
        [SerializeField] float discrepency = 1.00f;
        [SerializeField] float spawnChance = 0.5f;
        [SerializeField] Recycler recyclingBin = null;
        [SerializeField] float rate = .25f;
        [SerializeField] float delay = 1f;

        public void Activate(bool enable = true)
        {
            if (enable)
                InvokeRepeating("Launch", delay, rate);
            else
                CancelInvoke("Launch");
        }

        void Launch()
        {
            bool success = Random.Range(0f, 1f) <= spawnChance ? true : false;
            Type t = RandomlySelectType();
            if (active && success)
            {
                Ball ball = recyclingBin.Get(t);

                Initialize(ball, t);

                Throw(ball as ILaunchable);
            }
        }

        private Type RandomlySelectType()
        {
            int index = 0;
            if(GameManager.Current.NoBall)
            {
                return TypeHelper.Get(0);
            }

            do
            {
                index = UnityEngine.Random.Range(0, TypeHelper.Length-1);
            }
            while (GameManager.Current.BallTypes[index] == false);

            return TypeHelper.Get(index+1);
        }

        void Initialize(Ball ball, Type t)
        {
            ball.Initialize(launchPoint, recyclingBin, t);
        }

        void Throw(ILaunchable ball)
        {
            if (ball is ILaunchable)
            {
                float x = Random.Range(velocity.x - discrepency, velocity.x + discrepency);
                float y = Random.Range(velocity.y - discrepency, velocity.y + discrepency);
                ball.Launch(new Vector2(x, y));
            }
            else
            {
                throw new System.ArgumentException("Did not pass a type of ILaunchable.");
            }
        }

        bool active = true;
    }
}