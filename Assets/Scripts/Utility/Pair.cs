public class Pair<T, J>
{
    public T First { get; private set; }
    public J Second { get; private set; }

    public Pair(T obj1, J obj2) {
        First = obj1;
        Second = obj2;
    }
}
