using System.Collections;
using UnityEngine;

namespace Ball
{
    public delegate void BounceEventHandler(object sender, BounceEventArgs e);

    public class BounceEventArgs : System.EventArgs
    {
        public Vector3 Location { get; private set; }
        public BounceEventArgs(Vector3 location)
        {
            this.Location = location;
        }
    }

    public class Ball : MonoBehaviour, ILaunchable
    {

        public Type Type { get; private set; }
        public float Value { get; private set; }
        public float SquaredVelocity { get => rb.velocity.sqrMagnitude; }

        private System.EventHandler onFreeze;
        public event System.EventHandler OnFreeze { add => onFreeze += value; remove => onFreeze -= value; }

        private BounceEventHandler onBounce;
        public event BounceEventHandler OnBounce { add => onBounce += value; remove => onBounce -= value; }

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                onBounce?.Invoke(this, new BounceEventArgs(collision.transform.position));
            }
        }


        public void Initialize(Recycler reclaimer, Type type, float value)
        {
            this.reclaimer = reclaimer;
            this.Type = type;
            this.Value = value;
        }

        public void SetPosition(Vector2 position)
        {
            this.transform.position = position;
        }

        public void Freeze()
        {
            onFreeze?.Invoke(this, new System.EventArgs());
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

        [SerializeField] Recycler reclaimer;
        Rigidbody2D rb;
    }
}