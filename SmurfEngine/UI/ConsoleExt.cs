using System;
using System.Collections.Generic;
using System.Text;

namespace SmurfEngine.UI
{
    /// <summary>
    /// Wrapper for the console that allows for a simpler way to output colored text
    /// </summary>
    public static class ConsoleExt
    {
        public static ConsoleColor DefaultTextColor { get; private set; }
        public static ConsoleColor DefaultBackgroundColor { get; private set; }
        public static ConsoleColor PlayerNameColor => ConsoleColor.Green;
        public static ConsoleColor ItemQuantityColor => ConsoleColor.Cyan;
        public static ConsoleColor ItemNameColor => ConsoleColor.DarkCyan;

        static ConsoleExt()
        {
            DefaultTextColor = Console.ForegroundColor;
            DefaultBackgroundColor = Console.BackgroundColor;
        }

        public static void WriteColor(string text, ConsoleColor color)
        {
            SetTextColor(color);
            Console.Write(text);
            SetTextColor(DefaultTextColor);
        }

        public static void WriteColor(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            SetTextColor(textColor);
            SetBackgroundColor(backgroundColor);
            Console.Write(text);
            SetTextColor(DefaultTextColor);
            SetBackgroundColor(DefaultTextColor);
        }

        public static void WriteLineColor(string text, ConsoleColor color)
        {
            SetTextColor(color);
            Console.WriteLine(text);
            SetTextColor(DefaultTextColor);
        }

        public static void WriteLineColor(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            SetTextColor(textColor);
            SetBackgroundColor(backgroundColor);
            Console.WriteLine(text);
            SetTextColor(DefaultTextColor);
            SetBackgroundColor(DefaultTextColor);
        }

        private static void SetTextColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private static void SetBackgroundColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }
    }
}
