using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ball
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] Recycler recycler;
        Ball ball;
        public Ball SpawnBall()
        {
            ball = recycler.Get(Recycler.RandomlySelectType());
            ball.Freeze();
            ball.transform.position = new Vector2(0, 0);

            return ball;
        }
    }
}