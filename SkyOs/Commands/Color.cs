using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace SkyOs.Commands
{
    class Color : Command
    {
        public Color(String name) : base(name)
        {

        }

        public override String execute(string[] args)
        {
            Kernel.res = false;
            String response = "";
            switch (args[0])
            {
                case "red":
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    break;

                case "darkRed":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }

                    break;

                case "green":
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    break;

                case "darkGreen":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    break;

                case "blue":
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    break;

                case "darkBlue":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }

                    break;

                case "cyan":
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    break;

                case "darkCyan":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }

                    break;

                case "yellow":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }

                    break;

                case "white":
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    break;

                case "gray":
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    break;

                case "darkGray":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    break;

                case "black":
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    break;

                case "magneta":
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }

                    break;

                case "darkMagneta":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }

                    break;

                default:
                    response = "Unexpected argument: " + args[0];
                    break;
            }
            return response;
        }
    }
}
