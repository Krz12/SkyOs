using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class freespace : Command
    {
        string response;
        public freespace(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = true;
            try
            {
                long available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace("0:/");
                response = ("Available Free Space: " + available_space);
            }

            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return "";
        }
    }
}