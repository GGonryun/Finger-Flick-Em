using UnityEngine;

namespace Animation
{
    /// <summary>
    /// This animation will interpolate by easing at the beginning and the end w/ extra ease.
    /// </summary>
    public class Smootherstep : Animation
    {
        public override Vector2 TimingFunction(Vector2 from, Vector2 to, float t)
        {
            t = t* t *t * (t * (6f * t - 15f) + 10f);

            return Vector2.Lerp(from, to, t);
        }
    }
}