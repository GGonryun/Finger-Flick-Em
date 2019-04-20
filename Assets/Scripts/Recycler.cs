using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{
    Stack<Transform> basketballs = new Stack<Transform>(30);
    [SerializeField] Transform basketball = null;

    public void Reclaim(Transform basketball)
    {
        basketballs.Push(basketball);
        basketball.gameObject.SetActive(false);
    }

    public Transform Get()
    {
        Transform ball;
        if (basketballs.Count == 0)
            ball = Create();
        else
            ball = Recycle();

        return ball;
    }

    Transform Create()
    {
        return Instantiate(basketball, this.transform);
    }

    Transform Recycle()
    {
        Transform ball = basketballs.Pop();
        ball.gameObject.SetActive(true);
        return ball;
    }

}
