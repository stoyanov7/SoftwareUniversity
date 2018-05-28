namespace AirConditionerTesterSystem.Models.Contracts
{
    public interface IPlaneAirConditioner : IAirConditioner
    {
        int ElectricityUsed { get; }

        int VolumeCovered { get; }
    }
}