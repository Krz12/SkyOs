using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class write : Command
    {
        public write(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            string response;
            Kernel.res = true;
            try
            {
                FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(Kernel.path + args[0]).GetFileStream();

                if (fs.CanWrite)
                {
                    int ctr = 0;
                    StringBuilder sb = new StringBuilder();

                    foreach (String s in args)
                    {
                        if (ctr > 1)
                            sb.Append(s + ' ');

                        ++ctr;
                    }

                    String txt = sb.ToString();
                    Byte[] data = Encoding.ASCII.GetBytes(txt.Substring(0, txt.Length - 1));

                    fs.Write(data, 0, data.Length);
                    fs.Close();

                    response = "Sucesfully wrote file!";

                }

                else
                {
                    response = "Unable to write file! Not open for writing.";
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
