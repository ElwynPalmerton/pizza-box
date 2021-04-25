using System;
using sc = System.Console;

namespace PizzaBox.ConsoleDisplay
{
    public class UIDisplay
    {
        public static string GetUserInfo(string message)
        {
            sc.Write(message);
            string ReturnValue = sc.ReadLine();
            // sc.Clear();
            return ReturnValue;
        }

        public static void MenuTitle(string title)
        {
            sc.ForegroundColor = ConsoleColor.Blue;
            sc.WriteLine(title);
            sc.ResetColor();
            sc.WriteLine();
        }

    }
}
