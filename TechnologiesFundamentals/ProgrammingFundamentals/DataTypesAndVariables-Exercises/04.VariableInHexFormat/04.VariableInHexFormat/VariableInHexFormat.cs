﻿namespace _04.VariableInHexFormat
{
    using System;

    public class VariableInHexFormat
    {
        public static void Main(string[] args)
        {
            var variable = Console.ReadLine();
            Console.WriteLine(Convert.ToInt32(variable, 16));
        }
    } 
}