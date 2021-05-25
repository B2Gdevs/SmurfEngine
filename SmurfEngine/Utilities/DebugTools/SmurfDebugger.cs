using Newtonsoft.Json;
using SmurfEngine.Characters;
using SmurfEngine.Items;
using SmurfEngine.Utilities.Enums.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmurfEngine.Utilities.DebugTools
{
    public static class SmurfDebugger
    {
        public static string debugFilesPath = "./DebugFiles";
        public static string mockGameJsonFileName = "mockGame.json";

        public static void GenerateMockGameJson()
        {
            var inventory = new Inventory();

            inventory.Add(new Item("stick"), 2);
            var player = new Player("James", 30, inventory);

            var scene1 = new Scene
            {
                Display = "scene1 text",
                Items = new List<Item> { new Item("stick") },
                Name = "scene 1",
                Options = new List<Option>
                {
                    new Option { Name = "Scene 2", OptionType = OptionType.Scene },
                    new Option { Name = "Inventory", OptionType = OptionType.Inventory },
                    new Option { Name = "Exit", OptionType = OptionType.Exit }
                }
            };

            var scene2 = new Scene
            {
                Display = "scene2 text",
                Items = new List<Item>
                {
                    new Item("apple"),
                    new Item("pear"),
                },
                Name = "scene 2",
                Options = new List<Option>
                {
                    new Option { Name = "Scene 1", OptionType = OptionType.Scene },
                    new Option { Name = "Inventory", OptionType = OptionType.Inventory },
                    new Option { Name = "Exit", OptionType = OptionType.Exit }
                }
            };

            var scenes = new Dictionary<string, Scene>
            {
                { scene1.Name, scene1 },
                { scene2.Name, scene2 }
            };

            var game = new Game { Player = player, Scenes = scenes };

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            var jsonPlayer = JsonConvert.SerializeObject(game, settings);
            CreateDebugFilesFolder();

            File.WriteAllText(Path.Join(debugFilesPath, mockGameJsonFileName), jsonPlayer);
        }

        private static void CreateDebugFilesFolder()
        {
            Directory.CreateDirectory(debugFilesPath);
        }
    }
}
