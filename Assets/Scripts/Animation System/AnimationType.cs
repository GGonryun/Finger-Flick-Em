namespace Animation
{
    public enum Type { None, Smoothstep, Smootherstep, Exponential, EaseIn, EaseOut, SoftBoing, HardBoing }

    /// <summary>
    /// Simple Factory class for Animations.
    /// </summary>
    public static class Factory
    {
        readonly static Animation none = new NoAnimation();
        readonly static Animation smoothstep = new Smoothstep();
        readonly static Animation smootherstep = new Smootherstep();
        readonly static Animation exponential = new Exponential();
        readonly static Animation easeIn = new EaseIn();
        readonly static Animation easeOut = new EaseOut();
        readonly static Animation softBoing = new Boing(curvature: 1.2f);
        readonly static Animation hardBoing = new Boing(offset: .6f, intensity: 4.5f, amplitude: 1.1f, curvature: 1.1f);

        public static Animation Get(Type type)
        {
            switch (type)
            {
                case Type.Smoothstep:
                    return smoothstep;
                case Type.Smootherstep:
                    return smootherstep;
                case Type.Exponential:
                    return exponential;
                case Type.EaseIn:
                    return easeIn;
                case Type.EaseOut:
                    return easeOut;
                case Type.SoftBoing:
                    return softBoing;
                case Type.HardBoing:
                    return hardBoing;
                default:
                    return none;
            }
        }
    }
}