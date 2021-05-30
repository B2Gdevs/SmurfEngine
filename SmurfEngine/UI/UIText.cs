using System;

namespace SmurfEngine.UI
{
    public static class UIText
    {
        public static ConsoleColor defaultColor = ConsoleColor.Gray;
        public static ConsoleColor playerNameColor = ConsoleColor.Green;
        public static ConsoleColor itemQuantityColor = ConsoleColor.Cyan;
        public static ConsoleColor itemNameColor = ConsoleColor.DarkCyan;

        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
