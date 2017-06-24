using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ForumTopics
{
    public class ForumTopics
    {
        public static void Main(string[] args)
        {
            var topics = new Dictionary<string, HashSet<string>>();
            var line = Console.ReadLine();

            while (line != "filter")
            {
                ReadForumTopics(topics, line);

                line = Console.ReadLine();
            }

            var search = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            PrintForumTopics(topics, search);
        }

        private static void ReadForumTopics(Dictionary<string, HashSet<string>> topics, string line)
        {
            var lineTokens = line
                                .Split(new[] { ' ', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();

            var topic = lineTokens[0];
            var tags = lineTokens
                .Skip(1)
                .ToList();

            if (!topics.ContainsKey(topic))
            {
                topics.Add(topic, new HashSet<string>());
            }

            tags.ForEach(t => topics[topic].Add(t));
        }

        private static void PrintForumTopics(Dictionary<string, HashSet<string>> topics, string[] search)
        {
            foreach (var kvp in topics)
            {
                var topic = kvp.Key;
                var tags = string.Join(", ", topic.Select(t => $"#{t}"));
                var hasAllTags = CheckForTags(search, kvp.Value);

                if (hasAllTags)
                {
                    Console.WriteLine($"{topic} | {tags}");
                }
            }
        }

        private static bool CheckForTags(string[] inputTags, HashSet<string> topicTags)
        {
            var hasAllTags = true;

            foreach (var tag in inputTags)
            {
                if (!topicTags.Contains(tag))
                {
                    hasAllTags = false;
                    break;
                }
            }

            return hasAllTags;
        }
    }
}