using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Basketball : MonoBehaviour, ILaunchable
{
    public Recycler reclaimer;

    public void Initialize(Vector2 position, Recycler reclaimer)
    {
        this.reclaimer = reclaimer;
        this.transform.position = position;
    }

    public void Launch(Vector3 force)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = force;
        rb.angularVelocity = Random.Range(0f, 180f);
        StartCoroutine(Timeout());
    }
    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timer);
        reclaimer.Reclaim(this);
    }
    float timer = 8.0f;
}
