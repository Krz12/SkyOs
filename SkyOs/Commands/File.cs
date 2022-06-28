using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class File : Command
    {
        public File (String name) : base (name)
        {
            
        }

        public override String execute(string[] args)
        {
            //file create myfile.txt

            String response = "";
            Kernel.res = true;
            switch (args[0])
            {
                case "create":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateFile(Kernel.path + args[1]);
                        response = "Your file " + args[1] + " was sucessfully created!";
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
                        response = "Your file " +args[1] + " was sucessfully removed!";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "createdir":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(Kernel.path + args[1]);
                        response = "Sucessfully created directory " + args[1];
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "deletedir":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(Kernel.path + args[1],true);
                        response = "Sucessfully removed directory " + args[1];
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "delsys":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory("0:\\SkyOs", true);
                        response = "Sucessfully removed SkyOs from disk";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "write":
                    try
                    {
                        FileStream fs=(FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(Kernel.path + args[1]).GetFileStream();
                        
                        if (fs.CanWrite)
                        {
                            int ctr = 0;
                            StringBuilder sb = new StringBuilder();

                            foreach (String s in args)
                            {
                                if (ctr>1)
                                    sb.Append(s+' ');

                                ++ctr;
                            }

                            String txt = sb.ToString();
                            Byte[] data = Encoding.ASCII.GetBytes(txt.Substring(0,txt.Length-1));

                            fs.Write(data, 0, data.Length);
                            fs.Close();

                            response = "Sucesfully wrote file!";
                            
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

                case "read":
                    try
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(Kernel.path + args[1]).GetFileStream();

                        if (fs.CanRead)
                        {
                            Byte[] data = new Byte[256];

                            fs.Read(data, 0, data.Length);
                            response = Encoding.ASCII.GetString(data);
                        }

                        else
                        {
                            response = "Unable to read file! Not open for reading.";
                            break;
                        }
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "freespace":
                    try
                    {
                        long available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace("0:/");
                        response = ("Available Free Space: " + available_space);
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "gfst":
                    try
                    {
                        string fs_type = Sys.FileSystem.VFS.VFSManager.GetFileSystemType("0:/");
                        response = ("File System Type: " + fs_type);
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "lsdir":
                    try
                    {
                        var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(Kernel.path);
                        foreach (var directoryEntry in directory_list)
                        {
                            Console.WriteLine(directoryEntry.mName);
                        }
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "cd":
                    try
                    {
                        Kernel.path = Kernel.path+args[1];
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "\\":
                    try
                    {
                        Kernel.path = "0:\\";
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