namespace AirConditionerTesterSystem.Repositories
{
    using System.Collections.Generic;
    using Models.Contracts;

    public interface IAirConditionerTesterSystemData
    {
        IDictionary<string, IAirConditioner> AirConditioners { get; }

        IDictionary<string, IList<IReport>> Reports { get; }

        void AddAirConditioner(ICarAirConditioner carAirConditioner);
        void RemoveAirConditioner(ICarAirConditioner carAirConditioner);
        IAirConditioner GetAirConditioner(string manufacturer, string model);
        int GetAirConditionerCount();
        void AddReport(IReport report);
        void RemoveReport(IReport report);
        IReport GetReport(string manufacturer, string model);
        int GetReportsCount();
        IList<IReport> GetReportsByManufacturer(string manufacturer);
    }
}