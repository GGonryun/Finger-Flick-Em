using UnityEngine;
namespace Animation
{
    /// <summary>
    /// This animation will first overshoot, then waver back and forth around the end value before coming to a rest.
    /// </summary>
    public class Boing : Animation
    {
        public Boing(float offset = 0.2f, float intensity = 2.5f, float amplitude = 1.0f, float curvature = 1.5f)
        {
            this._offset = offset;
            this._intensity = intensity;
            this._amplitude = amplitude;
            this._curvature = curvature;
        }
       
        public override Vector2 TimingFunction(Vector2 from, Vector2 to, float t)
        {
            return new Vector2(CalculateBoingTime(from.x, to.x, t), CalculateBoingTime(from.y, to.y, t));
        }

        float CalculateBoingTime(float start, float end, float t)
        {
            // Desmos Function: 
            // y\ =\ \sin\left(x\ \cdot\ \pi\ \cdot\ \left(n+b\ \cdot\ x\ \cdot\ x\cdot x\right)\right)\ \cdot\ \left(v-x\right)^{2\ }+\ x\ \cdot\ \left(1+\left(c\cdot\left(1-x\right)\right)\right)
            t = Mathf.Clamp01(t);
            t = (Mathf.Sin(t * Mathf.PI * (_offset + _intensity * t * t * t)) * Mathf.Pow(_amplitude - t, 2.2f) + t) * (1f + (_curvature * (1f - t)));
            return start + (end - start) * t;
        }

        readonly float _offset;
        readonly float _intensity;
        readonly float _amplitude;
        readonly float _curvature;
    }
}