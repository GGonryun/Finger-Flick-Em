using UnityEngine;

namespace Animation
{
    public class EaseIn : Animation
    {
        public override float TimingFunction(float t)
        {
            return 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
        }
    }
}
