using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace SkyOs.Commands
{
    class Date : Command
    {
        public Date(String name) : base(name)
        {

        }

        public override String execute(string[] args)
        {
            //
            var dateYear = Cosmos.HAL.RTC.Year;
            var datem = Cosmos.HAL.RTC.Month;
            var datedm = Cosmos.HAL.RTC.DayOfTheMonth;
            var date = datedm + ":" + datem + ":" + dateYear;
            //

            String response = "";
            Kernel.res = false;
            switch (args[0])
            {
                case "y":
                    try
                    {
                        response = "Year: " + dateYear;
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
                        response = "Month: " + datem;
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "d":
                    try
                    {
                        response = "Day: " + datedm;
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
                        response = "date: " + date;
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
