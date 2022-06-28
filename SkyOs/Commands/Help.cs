using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace SkyOs.Commands
{
    class Help : Command
    {
        public Help(String name) : base(name)
        {

        }

        public override String execute(string[] args)
        {
            String response = "";
            Kernel.res = true;
            switch (args[0])
            {
                case "":
                    try
                    {
                        Console.WriteLine("---------------------------Help menu---------------------------");
                        Console.WriteLine("1. help");
                        Console.WriteLine("2. file");
                        Console.WriteLine("3. launchgui");
                        Console.WriteLine("4. clear");
                        Console.WriteLine("5. Power");
                        Console.WriteLine("6. time");
                        Console.WriteLine("7. date");
                        Console.WriteLine("8. run");
                        Console.WriteLine("9. list");
                        response =       ("---------------------------------------------------------------");
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "1":
                    try
                    {
                        response = "Show help menu";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "2":
                    try
                    {
                        Console.WriteLine("-------------------------File help menu-------------------------");
                        Console.WriteLine("create - Create file");
                        Console.WriteLine("delete - delete the file");
                        Console.WriteLine("createdir - create directory");
                        Console.WriteLine("deletedir - delete directory");
                        Console.WriteLine("write - write text to file");
                        Console.WriteLine("read - read text from file");
                        Console.WriteLine("freespace - show free space in bytes");
                        Console.WriteLine("lsdir - show file/dir in directory");
                        Console.WriteLine("gfst - get filesystem type");
                        response =        "----------------------------------------------------------------";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "3":
                    try
                    {
                        Console.WriteLine("-------------------------GUI help menu--------------------------");
                        Console.WriteLine("launchgui - launch gui");
                        response =        "----------------------------------------------------------------";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "4":
                    try
                    {
                        Console.WriteLine("-------------------------Clear help menu------------------------");
                        Console.WriteLine("clear - clear the screen");
                        response =        "----------------------------------------------------------------";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "5":
                    try
                    {
                        Console.WriteLine("-------------------------Power help menu------------------------");
                        Console.WriteLine("shoutdown - shoutdown the computer");
                        Console.WriteLine("restart - restart the computer");
                        response =        "----------------------------------------------------------------";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "6":
                    try
                    {
                        Console.WriteLine("-------------------------Time help menu-------------------------");
                        Console.WriteLine("a - show time");
                        Console.WriteLine("s - show secounds");
                        Console.WriteLine("m - show minutes");
                        Console.WriteLine("h - show hours");
                        response =        "----------------------------------------------------------------";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                    case "7":
                    try
                    {
                        Console.WriteLine("-------------------------Date help menu-------------------------");
                        Console.WriteLine("a - show date");
                        Console.WriteLine("d - show day of month");
                        Console.WriteLine("m - show month of year");
                        Console.WriteLine("y - show year");
                        response =        "----------------------------------------------------------------";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "8":
                    try
                    {
                        Console.WriteLine("-------------------------Run help menu--------------------------");
                        Console.WriteLine("ca - run ca application");
                        response =        "----------------------------------------------------------------";
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
