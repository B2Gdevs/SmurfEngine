using SmurfEngine.Utilities;
using System;

namespace SmurfEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new SmurfEngine();
            engine.Debug();
            engine.LoadGame("game.json");
            engine.Play();
        }
    }
}
