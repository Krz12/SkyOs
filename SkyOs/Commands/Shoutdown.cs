using System;
using System.Collections.Generic;
using System.Text;

namespace SkyOs.Commands
{
    class Shoutdown : Command
    {
        public Shoutdown(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            Cosmos.System.Power.Shutdown();
            return "";
        }
    }
}
