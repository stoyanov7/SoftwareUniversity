using System;

namespace _15.SpecialNums
{
    public class SpecialNums
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var isSpesialNum = true;

            for (var i1 = 1; i1 <= 9; i1++)
            {
                for (var i2 = 1; i2 <= 9; i2++)
                {
                    for (var i3 = 1; i3 <= 9; i3++)
                    {
                        for (var i4 = 1; i4 <= 9; i4++)
                        {
                            var number = i1.ToString() + i2 + i3 + i4;

                            foreach (var t in number)
                            {
                                var curentNum = (int)char.GetNumericValue(t);

                                if (n % curentNum == 0)
                                {
                                    isSpesialNum = true;
                                    continue;
                                }
                                else
                                {
                                    isSpesialNum = false;
                                    break;
                                }
                            }

                            if (isSpesialNum)
                            {
                                Console.Write(number + " ");
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
