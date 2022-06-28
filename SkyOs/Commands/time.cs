using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace SkyOs.Commands
{
    class Time : Command
    {
        public Time(String name) : base(name)
        {

        }

        public override String execute(string[] args)
        {
            //
            var timeSec = Cosmos.HAL.RTC.Second;
            var timeMinute = Cosmos.HAL.RTC.Minute;
            var timeHour = Cosmos.HAL.RTC.Hour;
            var time = timeHour + ":" + timeMinute + ":" + timeSec;
            //

            String response = "";
            Kernel.res = true;
            switch (args[0])
            {
                case "h":
                    try
                    {
                        response = "Hour:" + timeHour;
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "m":
                    try
                    {
                        response = "Minute:" + timeMinute;
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "s":
                    try
                    {
                        response = "Secound:" + timeSec;
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "a":
                    try
                    {
                        response = "time " + time;
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
