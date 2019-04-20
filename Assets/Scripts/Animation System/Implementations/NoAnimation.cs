namespace Animation
{
    public sealed class NoAnimation : Animation
    {
        public override float TimingFunction(float t)
        {
            return 1f;
        }
    }
}