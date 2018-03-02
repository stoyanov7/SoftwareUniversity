namespace Cars.Models
{
    public class Seat : Vehicle
    {
        public Seat(string model, string color)
            : base(model, color)
        {
        }

        public override string ToString() => $"{base.ToString()} {this.PrintEngine()}";
    }
}