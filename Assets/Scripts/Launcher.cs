using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] Transform basketball = null;
    [SerializeField] Vector3 launchPoint = Vector3.zero;
    [SerializeField] Vector2 velocity = Vector2.up;
    [SerializeField] float discrepency = 0.00f;
    [SerializeField] float spawnChance = 0f;
    [SerializeField] Recycler recyclingBin;

    void Awake()
    {
        InvokeRepeating("Launch", delay, rate);
    }

    void Launch()
    {
        bool success = Random.Range(0f, 1f) <= spawnChance ? true : false;

        if(active && success)
        {
            Transform ball = recyclingBin.Get();

            Throw(ball);

            Initialize(ball);

        }
    }

    private void Initialize(Transform ball)
    {
        Basketball bb = ball.GetComponent<Basketball>();
        bb.Initialize(recyclingBin);
    }

    private void Throw(Transform ball)
    {
        ball.position = launchPoint;
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }

    float rate = .1f;
    float delay = 1f;
    bool active = true;
}
