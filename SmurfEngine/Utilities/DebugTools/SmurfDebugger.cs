﻿using Newtonsoft.Json;
using SmurfEngine.Attributes;
using SmurfEngine.Characters;
using SmurfEngine.Items;
using SmurfEngine.Utilities.Enums;
using SmurfEngine.Utilities.Enums.Options;
using System.Collections.Generic;
using System.IO;

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

            var stats = new CharacterStats
            {
                Stats = new Dictionary<string, Stat>
                {
                    { StatType.STR.ToString(),
                        new Stat { Name = StatType.STR.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.INT.ToString(),
                        new Stat { Name = StatType.INT.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.WIS.ToString(),
                        new Stat { Name = StatType.WIS.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.DEX.ToString(),
                        new Stat { Name = StatType.DEX.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.CON.ToString(),
                        new Stat { Name = StatType.CON.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.CHA.ToString(),
                        new Stat { Name = StatType.CHA.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                }
            };

            var player = new Player("James", 30, inventory, stats);

            var scene1 = new Scene
            {
                Display = "scene1 text",
                Items = new List<Item> { new Item("stick") },
                Name = "scene 1",
                Options = new List<Option>
                {
                    new Option { Name = "Scene 2", OptionType = OptionType.Scene },
                    new Option { Name = "Inventory", OptionType = OptionType.Inventory },
                    new Option { Name = "Stats", OptionType = OptionType.Status },
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
                    new Option { Name = "Stats", OptionType = OptionType.Status },
                    new Option { Name = "Exit", OptionType = OptionType.Exit }
                }
            };

            var scenes = new Dictionary<string, Scene>
            {
                { scene1.Name, scene1 },
                { scene2.Name, scene2 }
            };

            var game = new Game { Player = player, Scenes = scenes };

            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };
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