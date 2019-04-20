using UnityEngine;

namespace Animation
{
    /// <summary>
    /// This animation will interpolate while easing around the end, when value is near one.
    /// </summary>
    public class EaseOut : Animation
    {
        public override Vector2 TimingFunction(Vector2 from, Vector2 to, float t)
        {
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            return Vector2.Lerp(from, to, t);
        }
    }
}