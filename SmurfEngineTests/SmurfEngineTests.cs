/**
* These unit tests are following the best practices found here. https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmurfEngine.Attributes;
using SmurfEngine.Characters;
using SmurfEngine.Items;
using SmurfEngine.Utilities;
using SmurfEngine.Utilities.Enums;
using SmurfEngine.Utilities.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmurfEngine.Tests
{
    [TestClass()]
    public class SmurfEngineTests
    {
        public string debugFilesPath = "./DebugFiles";
        public string mockGameJsonFileName = "fakeGame.json";

        public Game CreateFakeGame()
        {
            var inventory = new Inventory();

            inventory.Add(new Item("stick"), 2);

            CharacterStats stats = new CharacterStats
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
                    new SceneOption { Name = "Scene 2"},
                    new InventoryOption { Name = "Inventory"},
                    new ExitOption { Name = "Exit"}
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
                    new SceneOption { Name = "Scene 1" },
                    new InventoryOption { Name = "Inventory" },
                    new ExitOption { Name = "Exit" }
                }
            };

            var scenes = new Dictionary<string, Scene>
                {
                    { scene1.Name, scene1 },
                    { scene2.Name, scene2 }
                };

            var game = new Game { Player = player, Scenes = scenes };

            return game;
        }

        /// <summary>
        /// Test passes if now exception is thrown. This test just to see if the running
        /// game can be serialized.
        /// </summary>
        [TestMethod()]
        public void Serialize_GameFile_SaveGame()
        {
            #region Arrange
            var engine = new SmurfEngine();
            Game fakeGame = this.CreateFakeGame();
            #endregion Arrange

            #region Act
            engine.LoadGame(fakeGame);
            engine.SaveGame(this.mockGameJsonFileName, this.debugFilesPath);
            #endregion Act
        }

        /// <summary>
        /// This tests the loading of the game from the game file.  If no exceptions are
        /// thrown it passes.
        /// </summary>
        [TestMethod()]
        public void Deserialize_GameFile_LoadGame()
        {
            #region Arrange
            var engine = new SmurfEngine();
            #endregion Arrange

            #region Act
            engine.LoadGame(Path.Join(this.debugFilesPath, this.mockGameJsonFileName));
            #endregion Act
        }

        [TestMethod()]
        public void Reset_Scene_IsNull()
        {
            #region Arrange
            var engine = new SmurfEngine();
            Game fakeGame = this.CreateFakeGame();
            #endregion Arrange

            #region Act
            engine.LoadGame(fakeGame);
            engine.Reset();
            #endregion Act

            #region Assert
            Assert.IsNull(engine.CurrentScene);
            #endregion Assert
        }

        [TestMethod()]
        public void Reset_Game_IsNull()
        {
            #region Arrange
            var engine = new SmurfEngine();
            Game fakeGame = this.CreateFakeGame();
            #endregion Arrange

            #region Act
            engine.LoadGame(fakeGame);
            engine.Reset();
            #endregion Act

            #region Assert
            Assert.IsNull(engine.Game);
            #endregion Assert
        }

        [TestMethod()]
        public void Set_SceneByScene_SceneIsSet()
        {
            #region Arrange
            var engine = new SmurfEngine();
            Game fakeGame = this.CreateFakeGame();
            Scene nextScene = fakeGame.Scenes.Skip(1).First().Value;
            #endregion Arrange

            #region Act
            engine.LoadGame(fakeGame);
            engine.SetScene(nextScene);
            #endregion Act

            #region Assert
            Assert.AreEqual(nextScene, engine.CurrentScene);
            #endregion Assert
        }

        [TestMethod()]
        public void Set_SceneByOption_SceneIsSet()
        {
            #region Arrange
            var engine = new SmurfEngine();
            Game fakeGame = this.CreateFakeGame();
            Option option = fakeGame.Scenes.First()
                                           .Value
                                           .Options.First(option => option is SceneOption);
            #endregion Arrange

            #region Act
            engine.LoadGame(fakeGame);
            engine.SetScene((SceneOption)option);
            #endregion Act

            #region Assert
            Assert.AreEqual(option.Name.ToLower(), engine.CurrentScene.Name);
            #endregion Assert
        }
    }
}