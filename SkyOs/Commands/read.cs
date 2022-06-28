using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class Read : Command
    {
        public Read(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            string response;
            Kernel.res = true;
            try
            {
                FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(Kernel.path + args[0]).GetFileStream();

                if (fs.CanRead)
                {
                    Byte[] data = new Byte[256];

                    fs.Read(data, 0, data.Length);
                    response = Encoding.ASCII.GetString(data);
                }

                else
                {
                    response = "Unable to read file! Not open for reading.";
                }
            }

            catch (Exception ex)
            {
                response = ex.ToString();
            }
            return response;
        }
    }
}