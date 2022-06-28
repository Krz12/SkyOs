using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace SkyOs.Commands
{
    class Install : Command
    {
        public Install(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs");
            Console.WriteLine("Creating " + "0:\\SkyOs" + " was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs\\System");
            Console.WriteLine("Creating " + "0:\\SkyOs\\System" + " was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs\\System\\Temp");
            Console.WriteLine("Creating " + "0:\\SkyOs\\System\\Temp was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateFile("0:\\SkyOs\\System\\Temp\\Password.sky");
            Console.WriteLine("Creating " + "0:\\SkyOs\\System\\Temp\\Password.sky was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs\\System\\Settings");
            Console.WriteLine("Creating " + "0:\\SkyOs\\System\\Settings" + " was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateFile("0:\\SkyOs\\System\\Settings\\resolution.sky");
            Console.WriteLine("Creating " + "0:\\SkyOs\\System\\Settings\\resolution.sky" + " was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs\\System\\Files");
            Console.WriteLine("Creating " + "0:\\SkyOs\\System\\Files was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateFile("0:\\SkyOs\\System\\Files\\ii.sky");
            Console.WriteLine("Creating " + "0:\\SkyOs\\System\\Files\\ii.sky was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs\\Users");
            Console.WriteLine("Creating 0:\\SkyOs\\Users was sucessfully completed!");
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs\\System\\Users");
            Console.WriteLine("Creating 0:\\SkyOs\\System\\Users was sucessfully completed!");
            Console.WriteLine("Your username:");
            Kernel.UserName = Console.ReadLine();
            Console.WriteLine("Your password:");
            string UserPassword = Console.ReadLine();
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs\\Users\\" + Kernel.UserName);
            Sys.FileSystem.VFS.VFSManager.CreateDirectory("0:\\SkyOs\\System\\Users\\" + Kernel.UserName);
            Sys.FileSystem.VFS.VFSManager.CreateFile("0:\\SkyOs\\System\\Users\\"+ Kernel.UserName + "\\" + Kernel.UserName + ".sky");
            Console.WriteLine("Creating user was sucessfully completed!");
            //Completed
            FileStream fsi = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\SkyOs\\System\\Files\\ii.sky").GetFileStream();
            if (fsi.CanWrite)
            {
                byte[] text_to_write = Encoding.ASCII.GetBytes("1");
                fsi.Write(text_to_write, 0, text_to_write.Length);
                Console.WriteLine("Installing " + "0:\\SkyOs\\System\\Files\\ii.sky" + " was sucessfully completed!");
                fsi.Close();
            }
            FileStream fsu = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\SkyOs\\System\\Users\\" + Kernel.UserName + "\\" + Kernel.UserName + ".sky").GetFileStream();
            if (fsu.CanWrite)
            {
                byte[] text_to_write = Encoding.ASCII.GetBytes("    "+UserPassword);
                fsu.Write(text_to_write, 0, text_to_write.Length);
                fsu.Close();
            }
            FileStream fst = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\SkyOs\\System\\Temp\\Password.sky").GetFileStream();
            if (fst.CanWrite)
            {
                byte[] text_to_write = Encoding.ASCII.GetBytes("Null");
                fst.Write(text_to_write, 0, text_to_write.Length);
                Console.WriteLine("Installing 0:\\SkyOs\\System\\Temp\\Password.sky was sucessfully completed!");
                fst.Close();
            }
            FileStream fsr = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\SkyOs\\System\\Settings\\resolution.sky").GetFileStream();
            if (fsr.CanWrite)
            {
                Console.WriteLine("Your resolution x:");
                string resX = Console.ReadLine();
                Console.WriteLine("Your resolution y:");
                string resY = Console.ReadLine();
                byte[] text_to_write = Encoding.ASCII.GetBytes(resX+"x"+resY);
                fsr.Write(text_to_write, 0, text_to_write.Length);
                Console.WriteLine("Installing 0:\\SkyOs\\System\\Settings\\resolution.sky was sucessfully completed!");
                fsr.Close();
            }

            return "Instaltion complete. Your device need to restart";
            Sys.Power.Reboot();
        }
    }
}
