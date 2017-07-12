﻿namespace _03.ParseTags
{
    using System;

    public class ParseTags
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            var openTagIndex = text.IndexOf(openTag);
            var closeTagIndex = text.IndexOf(closeTag);

            while (openTagIndex != -1 && closeTagIndex != -1)
            {
                var textWithTags = text
                    .Substring(openTagIndex, (closeTagIndex + 9) - openTagIndex);
                var textToReplace = textWithTags
                    .Substring(8, textWithTags.Length - 17);
                text = text
                    .Replace(textWithTags, textToReplace.ToUpper());

                openTagIndex = text.IndexOf(openTag);
                closeTagIndex = text.IndexOf(closeTag);
            }

            Console.WriteLine(text);
        }
    }
}