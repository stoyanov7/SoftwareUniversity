namespace _04.RoliTheCoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class RoliTheCoder
    {
        public static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();
            var events = new Dictionary<int, Event>();
            const string eventPatern = @"(?<id>\d+)\s+#(?<eventName>[\w\d]+)(\s+(?:@\w+\s*)+)?";

            while (inputLine != "Time for Code")
            {
                var matchEventDetails = Regex.Match(inputLine, eventPatern);

                if (matchEventDetails.Success)
                {
                    var id = int.Parse(matchEventDetails.Groups["id"].Value);
                    var eventName = matchEventDetails
                        .Groups["eventName"]
                        .Value;

                    var participants = new string[0];
                    var eventHasPatricipants = inputLine.Contains("@");

                    if (eventHasPatricipants)
                    {
                        participants = inputLine
                            .Substring(inputLine.IndexOf("@"))
                            .Split();
                    }

                    if (!events.ContainsKey(id))
                    {
                        events[id] = new Event()
                        {
                            Name = eventName,
                            Participants = new List<string>()
                        };
                    }

                    if (events[id].Name == eventName)
                    {
                        events[id]
                            .Participants
                            .AddRange(participants);

                        events[id].Participants = events[id]
                            .Participants
                            .Distinct()
                            .ToList();
                    }
                }

                inputLine = Console.ReadLine();
            }

            var sortedEvents = events
                .OrderByDescending(e => e.Value.Participants.Count)
                .ThenBy(e => e.Value.Name)
                .ToArray();

            foreach (var @event in sortedEvents)
            {
                var eventName = @event
                    .Value
                    .Name;

                var participantsCount = @event
                    .Value
                    .Participants
                    .Count();

                var sortedParticipants = @event
                    .Value
                    .Participants
                    .OrderBy(p => p);

                Console.WriteLine($"{eventName} - {participantsCount}");

                foreach (var participants in sortedParticipants)
                {
                    Console.WriteLine(participants);
                }
            }
        }
    } 
}