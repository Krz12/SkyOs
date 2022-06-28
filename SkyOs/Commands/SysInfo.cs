using System;
using System.Collections.Generic;
using System.Text;

namespace SkyOs.Commands
{
    class SysInfo : Command
    {
        public SysInfo(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            Console.WriteLine("Os Name:    " + Kernel.OsName);
            Console.WriteLine("Os Version: " + Kernel.OsVersion);
            Console.WriteLine("Total Ram:  " + Kernel.TotalRam + "MB");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                          ..,           ");
            Console.WriteLine("                      ......,           ");
            Console.WriteLine("               .............,           ");
            Console.WriteLine("            ,,..............            ");
            Console.WriteLine("            ,,,,,,,,,,..                ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("            ,,,,,,,,,,,,,,,,            ");
            Console.WriteLine("            ,,,,,,,,,,,,,,,,            ");
            Console.WriteLine("            ,,,,,,,,,,,,,,,,            ");
            Console.WriteLine("                 ((,,,,,,,,,            ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("             (((((((((((((,,            ");
            Console.WriteLine("            ((((((((((((((              ");
            Console.WriteLine("            ((((((((((                  ");
            Console.WriteLine("            ((((((                      ");
            Console.WriteLine("            ((                          ");
            Console.ForegroundColor = ConsoleColor.White;
            return "";
        }
    }
}
