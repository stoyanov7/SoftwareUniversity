﻿namespace Avatar
{
    using System;
    using Controller;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            Console.WriteLine(engine.Run());
        }
    }
}