using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] Vector3 launchPoint = Vector3.zero;
    [SerializeField] Vector2 velocity = Vector2.up;
    [SerializeField] float discrepency = 0.00f;
    [SerializeField] float spawnChance = 0f;
    [SerializeField] Recycler recyclingBin = null;

    void Awake()
    {
        InvokeRepeating("Launch", delay, rate);
    }

    void Launch()
    {
        bool success = Random.Range(0f, 1f) <= spawnChance ? true : false;

        if (active && success)
        {
            Basketball ball = recyclingBin.Get();

            Initialize(ball);

            Throw(ball as ILaunchable);
        }
    }

    void Initialize(Basketball ball)
    {
        ball.Initialize(launchPoint, recyclingBin);
    }

    void Throw(ILaunchable ball)
    {
        if(ball is ILaunchable)
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

    float rate = .1f;
    float delay = 1f;
    bool active = true;
}
