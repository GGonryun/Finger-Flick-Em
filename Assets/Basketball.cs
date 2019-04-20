using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    public Recycler reclaimer;

    public void Initialize(Recycler reclaimer)
    {
        this.reclaimer = reclaimer;
        StartCoroutine(Timeout());
    }

    public IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timer);
        reclaimer.Reclaim(this.transform);
    }

    float timer = 4.0f;
}
