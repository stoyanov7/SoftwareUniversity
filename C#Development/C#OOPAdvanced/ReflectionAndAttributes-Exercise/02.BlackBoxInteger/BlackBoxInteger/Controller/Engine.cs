﻿namespace BlackBoxInteger.Controller
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Model;

    public class Engine
    {
        public void Run()
        {
            var type = typeof(BlackBoxInteger);
            var classInstance = Activator.CreateInstance(type, true);

            var methods = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var command = Console.ReadLine().Split('_');

            while (command[0] != "END")
            {
                var num = int.Parse(command[1]);

                methods
                    .FirstOrDefault(m => m.Name == command[0])
                    ?.Invoke(classInstance, new object[] { num });

                foreach (var field in fields)
                {
                    Console.WriteLine(field.GetValue(classInstance).ToString());
                }

                command = Console.ReadLine().Split('_');
            }
        }
    }
}