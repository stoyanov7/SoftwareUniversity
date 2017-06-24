using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SocialMediaPosts
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var postLikeDisLike = new Dictionary<string, List<int>>();
            var postComments = new Dictionary<string, List<string>>();

            while (line != "drop the media")
            {
                var lineTokens = line
                    .Split(' ')
                    .ToArray();
                var postName = lineTokens[1];

            //    if (!tokens[0].Equals("comment"))
            //    {
            //        if (!postLikeDisLike.ContainsKey(postName))
            //        {
            //            postLikeDisLike.Add(postName, new List<int>());
            //            postLikeDisLike[postName].Add(0);
            //            postLikeDisLike[postName].Add(0);
            //        }

            //        if (tokens[0].Equals("like"))
            //        {
            //            postLikeDisLike[postName][0]++;
            //        }
            //        else if (tokens[0].Equals("dislike"))
            //        {
            //            postLikeDisLike[postName][1]++;
            //        }
            //    }
            //    else
            //    {
            //        if (!postComments.ContainsKey(postName))
            //        {
            //            postComments.Add(postName, new List<string>());
            //        }

            //        postComments[postName].Add(tokens[2]);
            //        postComments[postName].Add(string.Join(" ", tokens.Skip(3)));
            //    }

            //    inputLine = Console.ReadLine();
            //}

            //foreach (var post in postLikeDisLike)
            //{
            //    Console.WriteLine($"Post: {post.Key} | Likes: {post.Value[0]} | Dislikes: {post.Value[1]}");

            //    Console.WriteLine("Comments:");
            //    if (!postComments.ContainsKey(post.Key))
            //    {
            //        Console.WriteLine("None");
            //        continue;
            //    }

            //    var comments = postComments[post.Key].ToList();

            //    for (int i = 0; i < comments.Count - 1; i+=2)
            //    {
            //        Console.WriteLine($"*  {comments[i]}: {comments[i+1]}");
            //    }  
            //}

        }
    }
}