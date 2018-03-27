namespace ArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item) => new T[length];
    }
}