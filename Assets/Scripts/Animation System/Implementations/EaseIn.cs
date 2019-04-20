using UnityEngine;

namespace Animation
{
    /// <summary>
    /// This animation will interpolate by easing at the beginning, when value is near zero.
    /// </summary>
    public class EaseIn : Animation
    {
        public override Vector2 TimingFunction(Vector2 from, Vector2 to, float t)
        {
            t = 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
            return Vector2.Lerp(from, to, t);
        }
    }
}
