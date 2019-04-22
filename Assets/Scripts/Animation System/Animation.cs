using System;
using System.Collections;
using UnityEngine;

namespace Animation
{
    /// <summary>
    /// Contains logic about how to animate an object by Lerping.
    /// </summary>
    /// If a new animation is implemented please add it to the "AnimationType.cs" enum, switch, and fields list.
    public abstract class Animation : IAnimation
    {
        /// <summary>
        /// Template method for animating objects.
        /// </summary>
        /// <param name="set">Provides the lerp-value over time, set it to the part of your object you wish to animate. </param>
        /// ex: (newScale) => transform.localScale = scale;
        public IEnumerator Animate(Action<Vector2> set, Vector2 start, Vector2 stop, float duration)
        {
            float elapsedTime = 0.0f;

            while (elapsedTime <= (duration))
            {
                float t = elapsedTime / duration;

                Vector2 interpolatedPoint = TimingFunction(start, stop, t);
                set(interpolatedPoint);

                yield return new WaitForEndOfFrame();
                elapsedTime += Time.deltaTime;
            }
            set(stop);
        }

        public abstract Vector2 TimingFunction(Vector2 from, Vector2 to, float time);

    }
}