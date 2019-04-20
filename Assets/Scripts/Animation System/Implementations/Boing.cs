using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Animation
{
    public class Boing : Animation
    {

        public override Vector2 TimingFunction(Vector2 from, Vector2 to, float t)
        {
           float time = (Mathf.Sin(t * Mathf.PI * (0.2f + 4 * t * t * t)) * Mathf.Pow(1.5f - t, 2.2f) + t) * (1f + (1.2f * (1f - t)));

        }
    }
}