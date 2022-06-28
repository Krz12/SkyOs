using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class delsys : Command
    {
        public delsys(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            try
            {
                Sys.FileSystem.VFS.VFSManager.DeleteDirectory("0:\\SkyOs", true);
                Console.WriteLine("Sucessfully removed SkyOs from disk");
            }
            catch (Exception ex)
            {
            }
            return "";
        }
    }
}