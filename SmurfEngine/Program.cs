using AngleSharp;
using AngleSharp.Dom;
using SmurfEngine.Attributes;
using SmurfEngine.Characters;
using SmurfEngine.Items;
using SmurfEngine.Utilities;
using SmurfEngine.Utilities.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            Game game = ReadTwine(filePath).Result;
            var engine = new SmurfEngine();
            engine.LoadGame(game);
            engine.Play();

        }

        public static async Task<Game> ReadTwine(string path)
        {

            IDocument document = await DeserializeTwineHTML(path);
            Dictionary<string, Scene> scenes = GetScenes(document);

            return new Game()
            {
                Scenes = scenes,
                Player = new Player("unnamed", 100, new Inventory(), new CharacterStats() { Stats = Stats.GetDefaultStats() })
            };
        }

        public static async Task<IDocument> DeserializeTwineHTML(string pathToTwine)
        {
            // Import Twine File
            using var r = new StreamReader(pathToTwine);
            var html = r.ReadToEnd();

            IConfiguration config = Configuration.Default;

            //Create a new context for evaluating webpages with the given config
            IBrowsingContext context = BrowsingContext.New(config);

            //Parse the document from the content of a response to a virtual request
            return await context.OpenAsync(req => req.Content(html));
        }

        /// <summary>
        /// Retrieves the scenes in the twine document.
        /// </summary>
        /// <param name="document">The deserialized twine HTML</param>
        /// <returns>A dictionary of scenes.</returns>
        public static Dictionary<string, Scene> GetScenes(IDocument document)
        {
            IHtmlCollection<IElement> passages = document.GetElementsByTagName("tw-passagedata");

            var scenes = new Dictionary<string, Scene>();

            foreach (IElement passage in passages.Skip(1))
            {
                scenes[passage.GetAttribute("name").ToLower()] = new Scene
                {
                    Name = passage.GetAttribute("name").ToLower(),
                    Display = SanitizeSceneText(passage.TextContent),
                    Options = GetOptions(passage.TextContent)
                };
            }

            return scenes;
        }

        /// <summary>
        /// Retrieves the options that are present in a given twine passage.  The twine passage comes
        /// directly from the inner portion of the following tag: <tw-passagedata>{twinePassageText}</tw-passagedata> .
        /// </summary>
        /// <param name="twinePassageText">The inner body of the tw-passagedata tag</param>
        /// <returns>The list of options found in the twine passage.</returns>
        public static List<Option> GetOptions(string twinePassageText)
        {
            string sceneName;
            string displayText;
            var options = new List<Option>();
            var optionRegexString = @"\[\[(.*?)\]\]";
            var optionRegex = new Regex(optionRegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = optionRegex.Matches(twinePassageText);

            // The scene matches.  These are all the links to the next scene
            foreach (var match in matches)
            {
                (displayText, sceneName) = ParsePassageLink(match.ToString());
                var sceneOption = new SceneOption()
                {
                    Name = sceneName?.ToLower() ?? displayText.ToLower(),
                    DisplayText = displayText
                };

                options.Add(sceneOption);
            }

            return options;
        }

        /// <summary>
        /// Cleans the display text of a scene from unnesscary leftovers from twine.  
        /// Removal of unecessary links and commentary
        /// </summary>
        /// <param name="sceneText">The twine passage text.</param>
        /// <returns>A clean scene text</returns>
        public static string SanitizeSceneText(string sceneText)
        {
            var optionRegexString = @"\[\[(.*?)\]\]";
            var metadataRegexString = @"\{([^}]+)\}";
            var optionRegex = new Regex(optionRegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var metadataRegex = new Regex(metadataRegexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection optionMatches = optionRegex.Matches(sceneText);
            MatchCollection metaDataMatches = metadataRegex.Matches(sceneText);

            Match optionMatch = optionMatches.FirstOrDefault();
            Match metaDataMatch = metaDataMatches.FirstOrDefault();
             
            sceneText = !(optionMatch is null) ? sceneText.Split(optionMatch.Value).FirstOrDefault() : sceneText;
            sceneText = !(metaDataMatch is null) ? sceneText.Split(metaDataMatch.Value).LastOrDefault() : sceneText ;
            return sceneText;
            
        }

        /// <summary>
        /// Parses the passage text to the format that smurf engine can understand.  This method
        /// returns a tuple where the first index is the display text and the second index is 
        /// the scene name.  The "Key" that will be used to go between scenes.
        /// </summary>
        /// <param name="passage">The main body of text in a Twine passage.</param>
        /// <returns>A tuple with the format (displayText, sceneName).</returns>
        public static Tuple<string, string> ParsePassageLink(string twineLinkText)
        {
            var charsToRemove = new string[] { "[[", "]]"};
            foreach (var c in charsToRemove)
            {
                twineLinkText = twineLinkText.Replace(c, string.Empty);
            }
            var links = twineLinkText.Split(new [] { "|", "->" }, StringSplitOptions.RemoveEmptyEntries);

            return links.Count() > 1
                ? new Tuple<string, string>(links[0], links[1])
                : links.Count() == 1 ? new Tuple<string, string>(links[0], null) : null;
        }

    }
}
