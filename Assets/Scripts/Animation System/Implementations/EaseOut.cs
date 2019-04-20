using UnityEngine;

namespace Animation
{
    public class EaseOut : Animation
    {
        public override float TimingFunction(float t)
        {
            return Mathf.Sin(t * Mathf.PI * 0.5f);
        }
    }
}