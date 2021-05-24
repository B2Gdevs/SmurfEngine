using System.Collections.Generic;
using SmurfEngine.Items;
using System;
using System.Linq;
using SmurfEngine.Utilities.Enums.Options;

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

            int index;
            try
            {
                if (int.TryParse(selection, out index))
                    return this.Options[index - 1];
                else
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
            int displayIndex = 1;
            foreach (var option in this.Options)
            {
                Console.WriteLine($"{displayIndex}: {option.Name}");
                displayIndex++;
            }
        }
    }
}
