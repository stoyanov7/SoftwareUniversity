using System;

namespace _08.MetricConverter
{
    public class MetricConverter
    {
        public static void Main(string[] args)
        {
            var number = double.Parse(Console.ReadLine());
            var sourceMetric = Console.ReadLine();
            var destMetric = Console.ReadLine();

            var baseMetricCoefficient = number;
            var coefficient = getCoefficient(sourceMetric);
            baseMetricCoefficient /= coefficient;

            coefficient = getCoefficient(destMetric);
            baseMetricCoefficient *= coefficient;

            Console.WriteLine($"{baseMetricCoefficient} {destMetric}");
        }

        private static double getCoefficient(string metric)
        {
            double result = 0;

            if (metric == "m")
            {
                result = 1;
            }
            else if (metric == "mm")
            {
                result = 1000;
            }
            else if (metric == "cm")
            {
                result = 100;
            }
            else if (metric == "mi")
            {
                result = 0.000621371192;
            }
            else if (metric == "in")
            {
                result = 39.3700787;
            }
            else if (metric == "km")
            {
                result = 0.001;
            }
            else if (metric == "ft")
            {
                result = 3.2808399;
            }
            else if (metric == "yd")
            {
                result = 1.0936133;
            }

            return result;
        }
    }
}