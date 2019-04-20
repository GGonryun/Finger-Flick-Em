using UnityEngine;

namespace Animation
{
    /// <summary>
    /// This animation will interpolate by easing at the beginning and the end w/ extra ease.
    /// </summary>
    public sealed class Smoothstep : Animation
    {
        public override Vector2 TimingFunction(Vector2 from, Vector2 to, float t)
        {
            t = t * t * (3f - 2f * t);

            return Vector2.Lerp(from, to, t);
        }
    }
}