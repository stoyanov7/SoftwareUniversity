namespace TrafficLights
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var trafficLightsStr = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            var allLights = trafficLightsStr.
                Select(t => (Light) Enum.Parse(typeof(Light), t))
                .Select(l => new TrafficLight(l))
                .ToList();

            for (var i = 1; i <= n; i++)
            {
                foreach (var light in allLights)
                {
                    light.SwitchState();
                }

                Console.WriteLine(string.Join(" ", allLights));
            }
        }
    }
}
