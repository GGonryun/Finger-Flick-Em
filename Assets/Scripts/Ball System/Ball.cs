using System.Collections;
using UnityEngine;

namespace Ball
{
    public class Ball : MonoBehaviour, ILaunchable
    {

        Recycler reclaimer;
        Rigidbody2D rb;
        public Type Type { get; private set; }

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
        }

        public void Initialize(Vector2 position, Recycler reclaimer, Type type)
        {
            this.reclaimer = reclaimer;
            this.transform.position = position;
            this.Type = type;
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
        }
        public void Reclaim()
        {
            reclaimer.Reclaim(this);
        }
    }
}