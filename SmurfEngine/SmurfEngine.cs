using Newtonsoft.Json;
using SmurfEngine.Utilities;
using SmurfEngine.Utilities.Options;
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
            while (true)
            {
                this.CurrentScene.DisplayText();
                Console.WriteLine("\n");
                this.CurrentScene.DisplayOptions();
                this.PerformOption(this.CurrentScene.GetOption());
                Console.WriteLine("\n\n");
            }
        }

        public void LoadGame(string path)
        {
            using var r = new StreamReader(path);
            var json = r.ReadToEnd();
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            this.Game = JsonConvert.DeserializeObject<Game>(json, settings);
            this.CurrentScene = this.Game.Scenes.First().Value;
        }

        public void LoadGame(Game game)
        {
            this.Game = game;
            this.CurrentScene = this.Game.Scenes.First().Value;
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

        public void SetScene(SceneOption option)
        {
            this.CurrentScene = this.Game.Scenes[option.Name.ToLower()];
            this.CurrentScene.NumVisits++;
        }

        public void SetScene(Scene scene)
        {
            this.CurrentScene = scene;
            this.CurrentScene.NumVisits++;
        }

        public void ExitGame()
        {
            Environment.Exit(0);
        }

        public void PerformOption(Option selectedOption)
        {
            if (selectedOption is ExitOption)
                this.ExitGame();

            if (selectedOption is InvalidOption)
            {
                Console.WriteLine("Invalid option selected. Please choose a valid option");
                return;
            }

            if (selectedOption is SceneOption option)
            {
                this.SetScene(option);
                return;
            }

            if (selectedOption is InventoryOption)
            {
                this.Game.Player.DisplayInventory();
                return;
            }
        }
    }
}
