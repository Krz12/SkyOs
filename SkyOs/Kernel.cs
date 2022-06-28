using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using SkyOs.Commands;
using Cosmos.System.FileSystem;
using System.IO;
using Cosmos.System.Network;
using SkyOs.Graphics;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using Cosmos.System.Network.IPv4.UDP.DNS;
using Cosmos.System.FileSystem.VFS;
using SkyOs.Graphics.GUI;

namespace SkyOs
{
    public class Kernel : Sys.Kernel
    {
        public static CommandManger commandManger;
        public static bool Booting;
        private CosmosVFS vfs;

        public static string OsName = "SkyOs";
        public static string OsVersion = "0.8";
        public static string path = "0:\\";
        public string User = "Root";
        public static bool res = false;
        public static string ii = "0";
        public static int resolutionX = 800;
        public static int resolutionY = 600;
        //Time
        public static int timeSec = Cosmos.HAL.RTC.Second;
        public static int timeMinute = Cosmos.HAL.RTC.Minute;
        public static int timeHour = Cosmos.HAL.RTC.Hour;
        public static string time = timeHour + ":" + timeMinute + ":" + timeSec;
        //Date
        public static string dateYear = Cosmos.HAL.RTC.Year.ToString();
        public static string datem = Cosmos.HAL.RTC.Month.ToString();
        public static string datedm = Cosmos.HAL.RTC.DayOfTheMonth.ToString();
        public static string date = datedm + ":" + datem + ":" + dateYear;
        //
        public static Canvas Canvas;
        public static bool CanvasE = false;
        //
        //Install strings
        public static string UserName = "Root";
        public static string iUserPassword = "Root";
        //End
        public static uint TotalRam = (Cosmos.Core.CPU.GetAmountOfRAM() + 2);
        protected override void BeforeRun()
        {
            List<string> optionList = new List<string>(new string[]
            {
                "Graphic mode", 
                "Console mode", 
                "Shutdown" 
            });
            ConsoleKey key;
            int selected = 0;
            Console.WriteLine(optionList);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Graphic mode");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Console mode");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Shoutdown - press esc");
            for (int i = 0; i == 0;)
            {
                bool le = true;
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (selected == 1)
                    {
                        if (le == true)
                        {
                            selected = 0;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Graphic mode         ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Console mode         ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Shoutdown - press esc");
                            le = false;
                        }
                    }
                }
                if (key == ConsoleKey.UpArrow)
                {
                    if (selected == 0)
                    {
                        if (le == true)
                        {
                            selected = 1;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Console mode         ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Graphic mode         ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Shoutdown - press esc");
                            le = true;
                        }
                    }
                }
                if (key == ConsoleKey.DownArrow)
                {
                    if (selected == 0)
                    {
                        if (le == true)
                        {
                            selected = 1;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Console mode         ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Graphic mode         ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Shoutdown - press esc");
                            le = false;
                        }
                    }

                }
                if (key == ConsoleKey.DownArrow)
                {
                    if (selected == 1)
                    {
                        if (le == true)
                        {
                            selected = 0;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Graphic mode         ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Console mode         ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("Shoutdown - press esc");
                        }
                    }
                }
                if (key == ConsoleKey.Enter)
                {
                    if (selected == 1)
                    {
                        i = 1;
                    }
                    if (selected == 0)
                    {
                        i = 1;
                        //zmienne
                        timeSec = Cosmos.HAL.RTC.Second;
                        timeMinute = Cosmos.HAL.RTC.Minute;
                        timeHour = Cosmos.HAL.RTC.Hour;
                        time = timeHour + ":" + timeMinute + ":" + timeSec;

                        try
                        {
                            FileStream ufr = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\SkyOs\\System\\Settings\\resolution.sky").GetFileStream();
                            Console.WriteLine("Stream succes");
                            if (ufr.CanRead)
                            {
                                string res = "";
                                Byte[] data = new Byte[256];
                                ufr.Read(data, 0, data.Length);
                                res = Encoding.ASCII.GetString(data);
                                Console.WriteLine("Resolution...");
                                //Kernel.resolutionX = int.Parse(res.Remove(res.IndexOf("x"), res.Length - res.IndexOf("x")));
                                Console.WriteLine(resolutionX);
                                //Kernel.resolutionY = int.Parse(res.Remove(0, res.Length - res.IndexOf("x")));
                                Console.WriteLine(resolutionY);
                            }
                        }
                        catch
                        {

                        }
                        CanvasE = true;
                        Canvas = new Canvas(Convert.ToUInt32(resolutionX), Convert.ToUInt32(resolutionY));
                        Canvas.Clear();
                        Canvas.DrawImage(Convert.ToInt32(Canvas.Width) / 2 - 128, Convert.ToInt32(Canvas.Height) / 2 - 128, 256, 256, Files.Logo);
                        Canvas.DrawString(Convert.ToInt32(Canvas.Width) / 2 - 304, Convert.ToInt32(Canvas.Height) / 2 + 128, $"SkyOS\nPowered by the cosmos Kernel, Prism OS", Theme.Default.Font, Graphics.Color.White);
                        Canvas.Update(false);
                        _ = new Applications.AppTemplate1();
                        _ = new Applications.TaskBar();
                        _ = new Applications.Menu();
                    }
                }
                if (key == ConsoleKey.Escape)
                {
                    Sys.Power.Shutdown();
                }
            }

            this.vfs = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);
            if (selected == 1)
            {
                Console.WriteLine("SkyOs Booting in console mode.");
                try
                {
                    if (Sys.FileSystem.VFS.VFSManager.FileExists("0:\\SkyOs\\System\\Files\\ii.sky"))
                    {
                        ii = "1";
                        Console.WriteLine("System is installed on disk!");
                    }
                }
                catch
                {
                    Console.WriteLine("System is not installed. To install SkyOs use: 'install'");
                    ii = "0";
                }
                if (ii == "1")
                {
                    for (int i = 0; i == 0;)
                    {
                        try
                        {
                            bool ue = false;
                            Console.WriteLine("Users list:");
                            var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing("0:\\SkyOs\\System\\Users\\");
                            foreach (var directoryEntry in directory_list)
                            {
                                Console.WriteLine(directoryEntry.mName);
                            }
                            Console.WriteLine("Chose user:");
                            var selectedUser = Console.ReadLine();
                            if (Sys.FileSystem.VFS.VFSManager.FileExists("0:\\SkyOs\\System\\Users\\" + selectedUser + "\\" + selectedUser + ".sky"))
                            {
                                ue = true;
                            }
                            else
                            {
                                ue = false;
                                Console.WriteLine("Selected user didn't exists");
                            }
                            if (ue == true)
                            {
                                Console.WriteLine("Password:");
                                string uP = Console.ReadLine();
                                try
                                {
                                    FileStream ufs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile("0:\\SkyOs\\System\\Users\\" + selectedUser + "\\" + selectedUser + ".sky").GetFileStream();

                                    if (ufs.CanRead)
                                    {
                                        string upass = "";
                                        Byte[] data = new Byte[256];
                                        ufs.Read(data, 0, data.Length);
                                        upass = Encoding.ASCII.GetString(data);
                                        upass = upass.Replace("Null", "");
                                        int upassl = upass.Length;
                                        Console.WriteLine(upass);
                                        upass.Remove(upass.IndexOf(""), upassl - upass.IndexOf(""));
                                        Console.WriteLine(upass);
                                        Console.WriteLine("Log: uP: " + uP);
                                        Console.WriteLine("Log: upass: " + "'" + upass + "'");
                                        if (upass != uP)
                                        {
                                            Console.WriteLine("Logged in succefuly!");
                                            User = selectedUser;
                                            i = 1;
                                            ufs.Close();
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("Unable to read User file!");
                                        break;
                                    }
                                }

                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.ToString());
                                }
                            }
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
            commandManger = new CommandManger();
    }


        protected override void Run()
        {
            //zmienne
            Kernel.timeSec = Cosmos.HAL.RTC.Second;
            Kernel.timeMinute = Cosmos.HAL.RTC.Minute;
            Kernel.timeHour = Cosmos.HAL.RTC.Hour;
            Kernel.time = timeHour + ":" + timeMinute + ":" + timeSec;
            //
            //var dateYear = Cosmos.HAL.RTC.Year;
            //var datem = Cosmos.HAL.RTC.Month;
            //var datedm = Cosmos.HAL.RTC.DayOfTheMonth;
            //var date = datedm + ":" + datem + ":" + dateYear;
            Console.Write(User + " " + path + "> ");
            //
            try
            {
                if (CanvasE == true)
                {
                    Canvas.DrawString(15, 15, $"FPS: {Canvas.FPS}", Theme.Default.Font, SkyOs.Graphics.Color.White);
                    UpdateTheme.updateTheme();
                    Runtime.Update();
                    Canvas.Update(true);
                    return;
                }
                res = true;
                String response;
                String input = Console.ReadLine();
                response = commandManger.processInput(input);
                if (res == true)
                {
                    Console.WriteLine(response);
                }

            }
            catch (Exception EX)
            {
                #region Crash Screen

                Canvas.Clear();
                Canvas.DrawImage(Convert.ToInt32(Canvas.Width) / 2 - 128, Convert.ToInt32(Canvas.Height) / 2 - 128, 256, 256, Files.Logo);
                string Error = $"[!] Critical failure [!]\nPrism OS has {(Booting ? "failed to boot" : "crashed")}! see error message below.\n" + EX.Message;
                Canvas.DrawString(Convert.ToInt32(Canvas.Width) / 2, Convert.ToInt32(Canvas.Height) / 2 + 128, Error, Graphics.Theme.Default.Font,Graphics.Color.Red, true);
                Canvas.Update(false);
                while (true) { }

                #endregion
            }
        }
    }
}
