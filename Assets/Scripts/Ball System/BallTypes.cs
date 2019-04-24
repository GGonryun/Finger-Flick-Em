namespace Ball
{
    public enum Type { Noneball, Tennisball, Football, Basketball, Volleyball, Soccerball }

    public static class TypeHelper
    {
        static readonly float[] _values = new float[6] { 0.1f, 0.5f, 2.0f, 1.0f, .7f, 1.25f };

        public static int Length => System.Enum.GetNames(typeof(Type)).Length;
        public static string Name(int i) => Get(i).ToString(); 
        public static Type Get(int i) => (Type)i;
        public static float Value(int i) => _values[i];
    }
}