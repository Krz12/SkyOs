using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class Utilities : Command
    {
        public Utilities(String name) : base(name)
        {

        }

        public override String execute(string[] args)
        {
            //file create myfile.txt

            String response = "";
            Kernel.res = true;
            switch (args[0])
            {
                case "editSysValue":
                    try
                    {
                        switch (args[1])
                        {
                            case "Kernel.path":
                                Kernel.path = args[2];
                                break;
                            case "Kernel.resolutionX":
                                Kernel.resolutionX = Int32.Parse(args[2]);
                                break;
                            case "Kernel.resolutionY":
                                Kernel.resolutionY = Int32.Parse(args[2]);
                                break;
                            case "GUI.menu":
                                SkyOs.Graphics.Varibles.menu = Boolean.Parse(args[2]);
                                break;
                            case "GUI.menu_power":
                                SkyOs.Graphics.Varibles.menu_power = Boolean.Parse(args[2]);
                                break;
                            case "GUI.theme":
                                SkyOs.Graphics.Varibles.theme = args[2];
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "delete":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(Kernel.path + args[1]);
                        response = "Your file " + args[1] + " was sucessfully removed!";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;

                default:
                    response = "Unexpected argument: " + args[0];
                    break;
            }
            return response;
        }
    }
}