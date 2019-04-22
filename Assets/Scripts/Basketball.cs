using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Basketball : MonoBehaviour, ILaunchable
{
    Recycler reclaimer;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    public void Initialize(Vector2 position, Recycler reclaimer)
    {
        this.reclaimer = reclaimer;
        this.transform.position = position;
    }

    public void Freeze()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;
    }

    public void Launch(Vector3 force)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = GameManager.Current.Gravity;
        rb.angularVelocity = Random.Range(0f, 180f);
        rb.velocity = force;
        StartCoroutine(Timeout());
    }
    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(timer);
        reclaimer.Reclaim(this);
    }
    float timer = 8.0f;
}
