using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
namespace SkyOs.Commands
{
    class createdir : Command
    {
        public createdir(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            try
            {
                Sys.FileSystem.VFS.VFSManager.CreateDirectory(Kernel.path + args[0]);
                Console.WriteLine("Sucessfully created directory " + args[0]);
            }
            catch (Exception ex)
            {
            }
            return "";
        }
    }
}
