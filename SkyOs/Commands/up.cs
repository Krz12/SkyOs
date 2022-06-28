using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class up : Command
    {
        public up(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            string response;
            try
            {
                Kernel.path = "0:\\";
            }

            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return "";
        }
    }
}
