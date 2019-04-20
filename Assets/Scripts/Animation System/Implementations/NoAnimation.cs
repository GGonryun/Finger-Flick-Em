using UnityEngine;

namespace Animation
{
    /// <summary>
    /// This animation moves the object to its destination immediately.
    /// </summary>
    public sealed class NoAnimation : Animation
    {
        public override Vector2 TimingFunction(Vector2 from, Vector2 to, float time)
        {
            return to;
        }
    }
}