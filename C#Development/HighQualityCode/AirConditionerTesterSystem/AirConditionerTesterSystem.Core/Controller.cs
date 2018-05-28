namespace AirConditionerTesterSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Exceptions;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Utilities;

    public class Controller : IController
    {
        private readonly IAirConditionerTesterSystemData data;

        public Controller(IAirConditionerTesterSystemData data)
        {
            this.data = data;
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, char energyEfficiencyRating, int powerUsage)
        {
            var stationaryAc = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            this.CheckForDuplicateEntry(stationaryAc);

            this.data
                .AirConditioners
                .Add(manufacturer + model, stationaryAc);

            return string.Format(Constants.RegisterMessage, stationaryAc.Model, stationaryAc.Manufacturer);
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            var carAirConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);
            this.CheckForDuplicateEntry(carAirConditioner);

            this.data
                .AirConditioners
                .Add(manufacturer + model, carAirConditioner);

            return string.Format(Constants.RegisterMessage, carAirConditioner.Model, carAirConditioner.Manufacturer);
        }

        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, int electricityUsed)
        {
            var planeAirConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            this.CheckForDuplicateEntry(planeAirConditioner);

            this.data
                .AirConditioners
                .Add(manufacturer + model, planeAirConditioner);

            return string.Format(Constants.RegisterMessage, planeAirConditioner.Model, planeAirConditioner.Manufacturer);
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            if (this.data.AirConditioners.ContainsKey(manufacturer + model))
            {
                var airConditioner = this.data.GetAirConditioner(manufacturer, model);
                var mark = airConditioner.Test();
                var report = new Report(airConditioner.Manufacturer, airConditioner.Model, mark);

                if (!this.data.Reports.ContainsKey(manufacturer))
                {
                    this.data.Reports.Add(manufacturer, new List<IReport>());
                    this.data.Reports[manufacturer].Add(report);
                }
                else
                {
                    if (this.data.Reports[manufacturer].Any(r => r.Model == model))
                    {
                        return Constants.Duplicate;
                    }
                    else
                    {
                        this.data.Reports[manufacturer].Add(report);
                    }
                }

                return string.Format(Constants.TestMessage, model, manufacturer);
            }

            return Constants.NonExistant;
        }

        public string FindAirConditioner(string manufacturer, string model)
        {
            var airConditioner = this.data.GetAirConditioner(manufacturer, model);

            return airConditioner?.ToString() ?? Constants.NonExistant;
        }

        public string FindReport(string manufacturer, string model)
        {
            var report = this.data.GetReport(manufacturer, model);

            return report?.ToString() ?? Constants.NonExistant;
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            var report = this.data.GetReportsByManufacturer(manufacturer);

            if (report == null)
            {
                return Constants.NoReports;
            }

            report = report
                .OrderBy(x => x.Model)
                .ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"Reports from {manufacturer}:")
                .Append(string.Join(Environment.NewLine, report));

            return sb.ToString().TrimEnd();
        }

        public string Status()
        {
            var reports = this.data.GetReportsCount();
            var airConditioners = (double)this.data.GetAirConditionerCount();
            var percent = reports / airConditioners;

            if (double.IsNaN(percent))
            {
                percent = 0d;
            }

            percent = percent * 100;

            return string.Format(Constants.Status, percent);
        }

        private void CheckForDuplicateEntry(IAirConditioner airConditioner)
        {
            if (this.data.AirConditioners.ContainsKey(airConditioner.Manufacturer + airConditioner.Model))
            {
                throw new DuplicateEntryException(Constants.Duplicate);
            }
        }
    }
}