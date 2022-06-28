using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class lsdir : Command
    {
        public lsdir(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            try
            {
                var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(Kernel.path+"\\");
                foreach (var directoryEntry in directory_list)
                {
                    Console.WriteLine(directoryEntry.mName);
                }
            }

            catch (Exception ex)
            {
            }
            return "";
        }
    }
}
