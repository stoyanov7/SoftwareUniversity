namespace AirConditionerTesterSystem.Models.Contracts
{
    public interface IReport
    {
        string Manufacturer { get; }

        int Mark { get; }

        string Model { get; }

        string ToString();
    }
}