namespace AirConditionerTesterSystem.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Contracts;

    public class AirConditionerTesterSystemData : IAirConditionerTesterSystemData
    {
        public AirConditionerTesterSystemData()
        {
            this.AirConditioners = new Dictionary<string, IAirConditioner>();
            this.Reports = new Dictionary<string, IList<IReport>>();
        }

        public IDictionary<string, IAirConditioner> AirConditioners { get; }

        public IDictionary<string, IList<IReport>> Reports { get; }

        public void AddAirConditioner(ICarAirConditioner carAirConditioner)
        {
            var key = carAirConditioner.Manufacturer + carAirConditioner.Model;
            this.AirConditioners.Add(key, carAirConditioner);
        }

        public void RemoveAirConditioner(ICarAirConditioner carAirConditioner)
        {
            var key = carAirConditioner.Manufacturer + carAirConditioner.Model;
            this.AirConditioners.Remove(key);
        }

        public IAirConditioner GetAirConditioner(string manufacturer, string model)
        {
            return this.AirConditioners.ContainsKey(manufacturer + model) 
                ? this.AirConditioners[manufacturer + model]
                : null;
        }

        public int GetAirConditionerCount() => this.AirConditioners.Count;

        public void AddReport(IReport report)
        {
            if (this.Reports.ContainsKey(report.Manufacturer))
            {
                this.Reports[report.Manufacturer].Add(report);
            }
            else
            {
                this.Reports.Add(report.Manufacturer, new List<IReport>());
                this.Reports[report.Manufacturer].Add(report);
            }
        }

        public void RemoveReport(IReport report) => this.Reports[report.Manufacturer].Remove(report);

        public IReport GetReport(string manufacturer, string model)
        {
            if (this.Reports.ContainsKey(manufacturer))
            {
                if (this.Reports[manufacturer].Count > 0)
                {
                    return this.Reports[manufacturer]
                        .FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
                }
            }

            return null;
        }

        public int GetReportsCount() => this.Reports.Sum(r => r.Value.Count);

        public IList<IReport> GetReportsByManufacturer(string manufacturer)
        {
            return this.Reports.ContainsKey(manufacturer)
                ? this.Reports[manufacturer] 
                : null;
        }
    }
}