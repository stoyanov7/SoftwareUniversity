namespace _02.SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniParty
    {
        public static void Main(string[] args)
        {
            var VIPGuests = new SortedSet<string>();
            var regularGuests = new SortedSet<string>();
            var line = Console.ReadLine();

            while (line != "PARTY")
            {
                if (char.IsDigit(line[0]))
                {
                    VIPGuests.Add(line);
                }
                else
                {
                    regularGuests.Add(line);
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "END")
            {
                if (char.IsDigit(line[0]) && VIPGuests.Contains(line))
                {
                    VIPGuests.Remove(line);
                }
                else
                {
                    regularGuests.Remove(line);
                }

                line = Console.ReadLine();
            }

            var allGuestsCount = VIPGuests.Count + regularGuests.Count();
            Console.WriteLine(allGuestsCount);

            foreach (var VIPGuest in VIPGuests)
            {
                Console.WriteLine(VIPGuest);
            }

            foreach (var regularGuest in regularGuests)
            {
                Console.WriteLine(regularGuest);

            }
        }
    }
}
