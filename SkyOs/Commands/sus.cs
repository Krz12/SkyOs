using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class sus : Command
    {
        public sus(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            Console.WriteLine("........*%@@@@%.........");
            Console.WriteLine("....,@@&%%%%%%%%@@......");
            Console.WriteLine("..&&&&###%&&&%%%%@@.....");
            Console.WriteLine("..&&&&###%&&&%%%%@@.....");
            Console.WriteLine(".&%,,,,,,,,/(&%%%&@@@@*.");
            Console.WriteLine(".&& (((((((((&&%%%&@&%%@");
            Console.WriteLine("..@@%&&&&&&%%%%%%&@@&&@@");
            Console.WriteLine("..@@%%%%%%%%%%%%&&@@&&@@");
            Console.WriteLine("..@@&%%%%%%%%%%&&&@&&&@@");
            Console.WriteLine("..%@&&&&&&&&&&&&&&@&&&@#");
            return "";
        }
    }
}
