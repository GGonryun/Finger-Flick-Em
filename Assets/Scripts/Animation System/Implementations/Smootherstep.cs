namespace Animation
{
    public class Smootherstep : Animation
    {
        public override float TimingFunction(float t)
        {
            return t * t * t * (t * (6f * t - 15f) + 10f);
        }
    }
}