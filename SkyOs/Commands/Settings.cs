using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class Settings : Command
    {
        public Settings(String name) : base(name)
        {

        }

        public override String execute(string[] args)
        {

            String response = "";
            Kernel.res = false;
            switch (args[0])
            {
                case "DefaultLaunch":
                    try
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\SkyOs\\System\\Settings\\DefaultLaunch.sky").GetFileStream();

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

                            response = "Sucesfully change settings!";

                        }

                        else
                        {
                            response = "Unable to write file! Not open for writing.";
                            break;
                        }
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "DefaultColor":
                    try
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

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

                            response = "Sucesfully change settings!";

                        }

                        else
                        {
                            response = "Unable to write file! Not open for writing.";
                            break;
                        }
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                default:
                    Console.WriteLine("Unexpected argument: " + args[0]);
                    Console.WriteLine("------------------------Settings Menu------------------------");
                    Console.WriteLine("1. Personalization:");
                    Console.WriteLine("    DefaultColor (any console color)");
                    Console.WriteLine("2. Others:");
                    Console.WriteLine("    DefaultLaunch 1 = graphcis mode; 2 = ConsoleMode");
                    Console.WriteLine("--------------------------------------------------------------");
                    break;
            }
            return response;
        }
    }
}
