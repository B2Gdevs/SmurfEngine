using Newtonsoft.Json;
using SmurfEngine.Characters;
using SmurfEngine.Items;
using SmurfEngine.Utilities;
using SmurfEngine.Utilities.DebugTools;
using SmurfEngine.Utilities.Enums.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmurfEngine
{
    class SmurfEngine
    {
        public Game Game { get; set; }
        public Scene CurrentScene { get; set; }

        public void Play()
        {
            var playing = true;
            Option selectedOption;
            this.CurrentScene = Game.Scenes.First().Value;
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

                if (selectedOption.OptionType is OptionType.Status)
                    this.Game.Player.DisplayStats();
            }
        }

        public void LoadGame(string path)
        {
            using StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            this.Game = JsonConvert.DeserializeObject<Game>(json, settings);
        }

        public void SetScene(Option option)
        {
            this.CurrentScene = this.Game.Scenes[option.Name.ToLower()];
        }

        public void Debug()
        {
            SmurfDebugger.GenerateMockGameJson();
        }
    }
}
