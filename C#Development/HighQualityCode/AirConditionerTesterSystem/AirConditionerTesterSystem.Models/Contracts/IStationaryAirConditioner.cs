namespace AirConditionerTesterSystem.Models.Contracts
{
    public interface IStationaryAirConditioner : IAirConditioner
    {
        char ActualEnergyEfficiencyRating { get; set; }

        int PowerUsage { get; }

        char RequiredEnergyEfficiencyRating { get; }
    }
}