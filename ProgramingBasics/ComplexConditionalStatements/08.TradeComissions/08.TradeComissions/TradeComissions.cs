using System;

namespace _08.TradeComissions
{
    public class TradeComissions
    {
        public static void Main(string[] args)
        {
            var town = Console.ReadLine();
            var sales = double.Parse(Console.ReadLine());
            var comission = -1d;

            switch (town)
            {
                case "Sofia":
                    if (sales >= 0 && sales <= 500)
                    {
                        comission = sales * 0.05;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        comission = sales * 0.07;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        comission = sales * 0.08;
                    }
                    else if (sales > 10000)
                    {
                        comission = sales * 0.12;
                    }
                    break;
                case "Varna":
                    if (sales >= 0 && sales <= 500)
                    {
                        comission = sales * 0.045;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        comission = sales * 0.075;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        comission = sales * 0.10;
                    }
                    else if (sales > 10000)
                    {
                        comission = sales * 0.13;
                    }
                    break;
                case "Plovdiv":
                    if (sales >= 0 && sales <= 500)
                    {
                        comission = sales * 0.055;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        comission = sales * 0.08;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        comission = sales * 0.12;
                    }
                    else if (sales > 10000)
                    {
                        comission = sales * 0.145;
                    }
                    break;
                default:
                    break;
            }

            Console.WriteLine(comission >= 0 ? $"{comission}" : "error");
        }
    }
}
