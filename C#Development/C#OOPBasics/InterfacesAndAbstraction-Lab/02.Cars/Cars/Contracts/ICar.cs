namespace Cars.Contracts
{
    public interface ICar
    {
        string Model { get; }

        string Color { get; }

        string PrintEngine();
    }
}