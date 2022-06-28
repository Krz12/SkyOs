using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class cd : Command
    {
        public cd(String name) : base(name)
        {

        }

        public override String execute(string[] args)
        {
            Kernel.res = false;
            try
            {
                if (Kernel.path != "0:\\")
                {
                    Kernel.path = Kernel.path + "\\" + args[0];
                }
                if (Kernel.path == "0:\\")
                {
                    Kernel.path = Kernel.path + args[0];
                }
            }

            catch (Exception ex)
            {
            }
            return "";
        }
    }
}
