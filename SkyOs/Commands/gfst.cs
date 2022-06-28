using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class gfst : Command
    {
        public gfst(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = true;
            string response;
            try
            {
                string fs_type = Sys.FileSystem.VFS.VFSManager.GetFileSystemType("0:/");
                response = ("File System Type: " + fs_type);
            }

            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return response;
        }
    }
}
