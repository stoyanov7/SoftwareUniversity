namespace _08.RawData
{
    public class Tire
    {
        private int age;
        private double pressure;

        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get; set; }
    
        public int Age { get; set; }
    }
}