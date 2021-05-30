namespace SmurfEngine
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var engine = new SmurfEngine();
            engine.LoadGame("game.json");
            engine.Play();
        }
    }
}
