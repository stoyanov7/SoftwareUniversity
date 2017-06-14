using System;

namespace _06.PointOnRectangleBorder
{
    public class PointOnRectangleBorder
    {
        public static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());

            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());

            var isOnLeftSide = (x == x1) && (y >= y1 && y <= y2);
            var isOnRightSide = (x == x2) && (y >= y1 && y <= y2);
            var isOnTopSide = (y == y1) && (x >= x1 && x <= x2);
            var isOnBottomSide = (y == y2) && (x >= x1 && x <= x2);

            if (isOnLeftSide || isOnRightSide || isOnTopSide || isOnBottomSide)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
