namespace AirConditionerTesterSystem.Models.Contracts
{
    using Enums;

    public interface IAirConditioner
    {
        string Manufacturer { get; }

        string Model { get; }

        Type Type { get; }

        int Test();
        string ToString();
    }
}