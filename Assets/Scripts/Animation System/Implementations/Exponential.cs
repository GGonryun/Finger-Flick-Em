using UnityEngine;

namespace Animation
{
    public sealed class Exponential : Animation
    {
        public override Vector2 TimingFunction(Vector2 from, Vector2 to, float t)
        {
            t *= t;
            return Vector2.Lerp(from, to, t);
        }
    }
}