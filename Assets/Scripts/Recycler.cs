using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{
    Stack<Basketball> basketballs = new Stack<Basketball>(30);
    [SerializeField] Basketball basketball = null;

    public void Reclaim(Basketball basketball)
    {
        lock (lockObject)
        {
            basketballs.Push(basketball);
        }
        basketball.gameObject.SetActive(false);
    }

    public Basketball Get()
    {
        Basketball ball;
        if (basketballs.Count == 0)
            ball = Create();
        else
            ball = Recycle();

        return ball;
    }

    Basketball Create()
    {
        return Instantiate(basketball, this.transform);
    }

    Basketball Recycle()
    {
        Basketball ball;
        lock (lockObject)
        {
             ball = basketballs.Pop();
        }
        ball.gameObject.SetActive(true);
        return ball;
    }

    Object lockObject = new Object();
}
