using SmurfEngine.Characters;
using System.Collections.Generic;

namespace SmurfEngine.Utilities
{
    public class Game
    {
        public Player Player { get; set; }
        public Dictionary<string, Scene> Scenes { get; set; }
    }
}
