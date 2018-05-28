namespace AirConditionerTesterSystem.Models.Contracts
{
    public interface ICarAirConditioner : IAirConditioner
    {
        int VolumeCovered { get; }
    }
}