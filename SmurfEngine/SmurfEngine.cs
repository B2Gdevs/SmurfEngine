using Newtonsoft.Json;
using SmurfEngine.Utilities;
using SmurfEngine.Utilities.Enums.Options;
using System;
using System.IO;
using System.Linq;

namespace SmurfEngine
{
    public class SmurfEngine
    {
        public Game Game { get; set; }
        public Scene CurrentScene { get; set; }

        public void Play()
        {
            var playing = true;
            Option selectedOption;
            this.CurrentScene = this.Game.Scenes.First().Value;
            while (playing)
            {
                selectedOption = this.CurrentScene.GetOption();

                if (selectedOption.OptionType is OptionType.Invalid)
                {
                    Console.WriteLine("Invalid option selected. Please choose a valid option");
                    continue;
                }

                if (selectedOption.OptionType is OptionType.Exit)
                    Environment.Exit(0);

                if (selectedOption.OptionType is OptionType.Scene)
                    this.SetScene(selectedOption);

                if (selectedOption.OptionType is OptionType.Inventory)
                    this.Game.Player.DisplayInventory();
            }
        }

        public void LoadGame(string path)
        {
            using var r = new StreamReader(path);
            var json = r.ReadToEnd();
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            this.Game = JsonConvert.DeserializeObject<Game>(json, settings);
        }

        public void LoadGame(Game game)
        {
            this.Game = game;
        }

        public void SaveGame(string fileName, string path)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var serializedGame = JsonConvert.SerializeObject(this.Game, settings);
            Directory.CreateDirectory(path);
            File.WriteAllText(Path.Join(path, fileName), serializedGame);
        }

        public void Reset()
        {
            this.Game = null;
            this.CurrentScene = null;
        }

        public void SetScene(Option option)
        {
            this.CurrentScene = this.Game.Scenes[option.Name.ToLower()];
        }
        public void SetScene(Scene scene)
        {
            this.CurrentScene = scene;
        }
    }
}
