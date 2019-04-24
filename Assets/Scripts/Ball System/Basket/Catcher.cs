using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType { Enter, Exit }

namespace Ball.Basket
{
    
    public delegate void OnTriggerEventHandler(object sender, OnTriggerEventArgs e);

    public class OnTriggerEventArgs : System.EventArgs
    {
        public TriggerType Type { get; private set; }
        public Collider2D Collision { get; private set; }

        public OnTriggerEventArgs(Collider2D collision, TriggerType type)
        {
            this.Collision = collision;
            this.Type = type;
        }
    }

    public class Catcher : MonoBehaviour
    {
        [SerializeField] TriggerRegion entrance = null;
        [SerializeField] TriggerRegion exit = null;
        string detect = "Ball";
        float delay = 0.25f;

        void Awake()
        {
            entrance.Detect(detect);
            exit.Detect(detect);
        }

        void OnEnable()
        {
            entrance.OnTrigger += Cache;
            exit.OnTrigger += Remove;
        }

        void OnDisable()
        {
            entrance.OnTrigger -= Cache;
            exit.OnTrigger -= Remove;
        }

        public void Cache(object sender, OnTriggerEventArgs args)
        {
            if (!args.Type.Equals(TriggerType.Enter))
                return;
            if (!ValidateCollision(args))
                return;

            if(!ready)
                ready = true;

        }

        public void Remove(object sender, OnTriggerEventArgs args)
        {
            if (!args.Type.Equals(TriggerType.Exit)) return;

            if (!ValidateCollision(args)) return;

            if(ready)
            {
                ready = false;
                Ball ball = args.Collision.gameObject.GetComponent<Ball>();
                GameManager.Current.IncreaseScore(ball);
            }
        }

        bool ValidateCollision(OnTriggerEventArgs args)
        {
            Collider2D collision = args.Collision;
            Rigidbody2D rb = collision.attachedRigidbody;
            if (rb.velocity.y >= 0) return false;
            return true;
        }

        bool ready = false;

    }
}