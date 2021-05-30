using SmurfEngine.Items;
using SmurfEngine.Utilities.Enums.Options;
using System;
using System.Collections.Generic;

namespace SmurfEngine.Utilities
{
    public class Scene
    {
        public string Name { get; set; }
        public List<Option> Options { get; set; }
        public string Display { get; set; }
        public List<Item> Items { get; set; }

        public Option GetOption()
        {
            this.DisplayOptions();
            var selection = Console.ReadLine();

            try
            {
                if (int.TryParse(selection, out var index))
                    return this.Options[EngineRunningUtilities.GetFirstNumber(index) - 1];
                
                return new Option { OptionType = OptionType.Invalid };

            }
            catch (Exception ex) when (ex is IndexOutOfRangeException)
            {
                return new Option { OptionType = OptionType.Invalid };
            }

        }

        /// <summary>
        /// Displays the options of the scene.
        /// </summary>
        /// <param name="options">A dictionary with the names display text as the keys and values are enum options</param>
        public void DisplayOptions()
        {
            var displayIndex = 1;
            foreach (Option option in this.Options)
            {
                Console.WriteLine($"{displayIndex}: {option.Name}");
                displayIndex++;
            }
        }
    }
}
