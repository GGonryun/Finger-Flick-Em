namespace Ball
{
    public enum Type { Noneball, Tennisball, Football, Basketball, Volleyball, Soccerball }

    public static class TypeHelper
    {
        public static int Length => System.Enum.GetNames(typeof(Type)).Length;
        public static string Name(int i) => Get(i).ToString(); 
        public static Type Get(int i) => (Type)i;
    }
}