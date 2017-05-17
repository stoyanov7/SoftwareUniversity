using System;

namespace _05.DistanceOfTheStars
{
    public class DistanceOfTheStars
    {
        public static void Main(string[] args)
        {
            var oneLightYear = 9450000000000m;
            var fromEarthToProximaCentauri = 4.22m * oneLightYear;
            var centerOfOurGalaxyToMilkyWay = 26000m * oneLightYear;
            var diameterOfMilkyWay = 100000m * oneLightYear;
            var distanceFromEarthToTheEdgeOfTheObservableniverse = 46500000000m * oneLightYear;

            Console.WriteLine(string.Format($"{fromEarthToProximaCentauri:e2}"));
            Console.WriteLine(string.Format($"{centerOfOurGalaxyToMilkyWay:e2}"));
            Console.WriteLine(string.Format($"{diameterOfMilkyWay:e2}"));
            Console.WriteLine(string.Format($"{distanceFromEarthToTheEdgeOfTheObservableniverse:e2}"));
        }
    }
}