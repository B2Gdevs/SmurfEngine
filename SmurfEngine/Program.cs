using AngleSharp;
using SmurfEngine.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmurfEngine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var engine = new SmurfEngine();
            //engine.LoadGame("game.json");
            //engine.Play();
            var filePath = "C:\\Users\\Haxe2\\Documents\\TwineStories\\TwineStory_files\\index.html";
            ReadTwine(filePath);

        }

        public static async void ReadTwine(string path)
        {
            // Import Twine File
            using var r = new StreamReader(path);
            var html = r.ReadToEnd();

            var rx = new Regex(@"\[\[(.*?)\]\]", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //var stuff = rx.Matches(html);
            //Console.WriteLine(stuff.First());

            var config = Configuration.Default;

            //Create a new context for evaluating webpages with the given config
            var context = BrowsingContext.New(config);

            //Parse the document from the content of a response to a virtual request
            var document = await context.OpenAsync(req => req.Content(html));

            var passages = document.GetElementsByTagName("tw-passagedata");

            //Do something with document like the following
            //Console.WriteLine(passages.First().GetAttribute("pid"));
            //Console.WriteLine(passages.First().GetAttribute("name"));
            //Console.WriteLine(passages.First().GetAttribute("tags"));
            //Console.WriteLine(passages.First().TextContent);
            var scenes = new Dictionary<string, Scene>();

            foreach (var passage in passages)
            {
                scenes[passage.GetAttribute("name")] = new Scene
                {
                    Name = passage.GetAttribute("name"),
                    Display = passage.TextContent
                };
            }

            string sceneName;
            string displayText;
            foreach (var scene in scenes)
            {
                //Console.WriteLine(scene.Value.Display);
                var matches = rx.Matches(scene.Value.Display);
                foreach(var match in matches)
                {
                    (displayText, sceneName) = ParsePassageLink(match.ToString());
                    Console.WriteLine("group");
                    Console.WriteLine(displayText);
                    Console.WriteLine(sceneName);
                    Console.WriteLine("efgroup");
                }
            }
        }

        public static Tuple<string, string> ParsePassageLink(string passage)
        {
            var charsToRemove = new string[] { "[[", "]]"};
            foreach (var c in charsToRemove)
            {
                passage = passage.Replace(c, string.Empty);
            }
            var links = passage.Split(new [] { "|", "->" }, StringSplitOptions.RemoveEmptyEntries);

            if (links.Count() > 1) 
                return new Tuple<string, string>(links[0], links[1]);

            if (links.Count() == 1)
                return new Tuple<string, string>(links[0], null);

            return null;

        }

    }
}
