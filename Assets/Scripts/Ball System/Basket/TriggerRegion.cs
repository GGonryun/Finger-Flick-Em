using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ball.Basket
{
    public class TriggerRegion : MonoBehaviour
    {
        public event OnTriggerEventHandler OnTrigger { add => onTrigger += value; remove => onTrigger -= value; }

        public void Detect(string tag) => detect = tag;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(detect))
                onTrigger?.Invoke(this, new OnTriggerEventArgs(collision, TriggerType.Enter));
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(detect))
                onTrigger?.Invoke(this, new OnTriggerEventArgs(collision, TriggerType.Exit));
        }

        OnTriggerEventHandler onTrigger;
        string detect = "";

    }
}
