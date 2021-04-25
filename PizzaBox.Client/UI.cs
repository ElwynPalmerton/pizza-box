using System;
using System.Collections.Generic;
using sc = System.Console;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client.Helpers
{

    public class UserInterface
    {        
        public static string GetUserInfo(string message)
        {
            sc.Write(message);
            string ReturnValue = sc.ReadLine();
            // sc.Clear();
            return ReturnValue;
        }

        public static void InvalidEntry(string entry)
        {
            sc.Clear();
            sc.WriteLine();
            sc.ForegroundColor = ConsoleColor.Magenta;
            sc.WriteLine(entry + " is not a valid entry.");
            Console.ResetColor();
        }

        public static bool CheckValidNumber(string entry, int range)
        {
            int i = 0; 
            bool isInRange = false;
            bool isANumber = int.TryParse(entry, out i); 
            if (isANumber)
            {
                int entryInt = int.Parse(entry);
                isInRange = entryInt >= 0 && entryInt <= range;
            }
            return isANumber && isInRange;
        }

        public static void MenuTitle(string title)
        {
            sc.ForegroundColor = ConsoleColor.Blue;
            sc.WriteLine(title);
            sc.ResetColor();
            sc.WriteLine();
        }

        public static void WelcomeToPizzaBox()
        {
                   var arr = new[]
            {
                @"       Welcome to...                                                                          ",
                @"                                                                                              ",
                @"        _______   ______  ________  ________   ______   _______    ______   __    __          ",
                @"       /       \ /      |/        |/        | /      \ /       \  /      \ /  |  /  |         ",
                @"       $$$$$$$  |$$$$$$/ $$$$$$$$/ $$$$$$$$/ /$$$$$$  |$$$$$$$  |/$$$$$$  |$$ |  $$ |         ",
                @"       $$ |__$$ |  $$ |      /$$/      /$$/  $$ |__$$ |$$ |__$$ |$$ |  $$ |$$  \/$$/          ",
                @"       $$    $$/   $$ |     /$$/      /$$/   $$    $$ |$$    $$< $$ |  $$ | $$  $$<           ",
                @"       $$$$$$$/    $$ |    /$$/      /$$/    $$$$$$$$ |$$$$$$$  |$$ |  $$ |  $$$$  \          ",
                @"       $$ |       _$$ |_  /$$/____  /$$/____ $$ |  $$ |$$ |__$$ |$$ \__$$ | $$ /$$  |         ",
                @"       $$ |      / $$   |/$$      |/$$      |$$ |  $$ |$$    $$/ $$    $$/ $$ |  $$ |         ",
                @"       $$/       $$$$$$/ $$$$$$$$/ $$$$$$$$/ $$/   $$/ $$$$$$$/   $$$$$$/  $$/   $$/          ",
                @"                                                                                              ",
                @"                                       ___                                                    ",
                @"                                        |  ~~--.                                              ",
                @"                                        |%=@%%/                                               ",
                @"                                        |o%%%/                                                ",
                @"                                     __ |%%o/                                                 ",
                @"                               _,--~~ | |(_/ ._                                               ",
                @"                            ,/'  m%%%%| |o/ /  `\.                                            ",
                @"                           /' m%%o(_)%| |/ /o%%m `\                                           ",
                @"                         /' %%@=%o%%%o|   /(_)o%%% `\                                         ",
                @"                        /  %o%%%%%=@%%|  /%%o%%@=%%  \                                        ",
                @"                       |  (_)%(_)%%o%%| /%%%=@(_)%%%  |                                       ",
                @"                       | %%o%%%%o%%%(_|/%o%%o%%%%o%%% |                                       ",
                @"                       | %%o%(_)%%%%%o%(_)%%%o%%o%o%% |                                       ",
                @"                       |  (_)%%=@%(_)%o%o%%(_)%o(_)%  |                                       ",
                @"                        \ ~%%o%%%%%o%o%=@%%o%%@%%o%~ /                                        ",
                @"                         \. ~o%%(_)%%%o%(_)%%(_)o~ ,/                                         ",
                @"                           \_ ~o%=@%(_)%o%%(_)%~ _/                                           ",
                @"                             `\_~~o%%%o%%%%%~~_/'                                             ",
                @"                                `--..____,,--'                                                ",
                @"                                                                                              ",
                @"                                                                                              ",
                                             
            };

            sc.BackgroundColor = ConsoleColor.DarkRed;
            sc.ForegroundColor = ConsoleColor.Yellow;
            sc.Clear();
            sc.WriteLine("\n\n");

            foreach(string line in arr )
                sc.WriteLine(line);
            sc.ResetColor();
            sc.WriteLine("Press any key to begin.");
            sc.WriteLine("");
            sc.ReadKey();
        }
    }
}