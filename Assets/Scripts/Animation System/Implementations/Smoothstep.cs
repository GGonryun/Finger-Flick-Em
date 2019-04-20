namespace Animation
{
    public sealed class Smoothstep : Animation
    {

        public override float TimingFunction(float t)
        {
            //smoother step.
            return t * t * (3f - 2f * t);
        }
    }
}