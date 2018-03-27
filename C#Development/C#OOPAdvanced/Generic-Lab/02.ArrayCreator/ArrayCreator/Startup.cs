namespace ArrayCreator
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var strings = ArrayCreator.Create(5, "Pesho");
            var integers = ArrayCreator.Create(10, 33);
        }
    }
}
