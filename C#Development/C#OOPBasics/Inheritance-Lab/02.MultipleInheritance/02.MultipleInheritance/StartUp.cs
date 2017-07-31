namespace _02.MultipleInheritance
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();
        }
    }
}