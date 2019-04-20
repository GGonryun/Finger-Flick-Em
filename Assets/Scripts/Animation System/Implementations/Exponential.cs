namespace Animation
{
    public sealed class Exponential : Animation
    {
        public override float TimingFunction(float t)
        {
            return t * t;
        }
    }
}