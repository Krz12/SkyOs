using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class create : Command
    {
        public create(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            try
            {
                Sys.FileSystem.VFS.VFSManager.CreateFile(Kernel.path + args[0]);
                Console.WriteLine("Your file " + args[0] + " was sucessfully created!");
            }
            catch (Exception ex)
            {
            }
            return "";
        }
    }
}
