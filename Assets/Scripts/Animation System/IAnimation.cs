using System;
using System.Collections;
using UnityEngine;

namespace Animation
{
    public interface IAnimation
    {
        IEnumerator Animate(Action<Vector2> SetPosition, Vector2 start, Vector2 stop, float duration);
    }
}