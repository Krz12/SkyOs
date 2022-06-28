using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class deletedir : Command
    {
        public deletedir(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            try
            {
                Sys.FileSystem.VFS.VFSManager.DeleteDirectory(Kernel.path + args[0], true);
                Console.WriteLine("Sucessfully removed directory " + args[0]);
            }
            catch (Exception ex)
            {
            }
            return "";
        }
    }
}
