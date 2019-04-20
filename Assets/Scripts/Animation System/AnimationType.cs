namespace Animation
{
    public enum Type { None, Smoothstep, Smootherstep, Exponential, EaseIn, EaseOut, Boing }

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
        readonly static Animation boing = new Boing();

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
                case Type.Boing:
                    return boing;
                default:
                    return none;
            }
        }
    }
}