using System;
using System.Collections.Generic;
using System.Text;

namespace SkyOs.Commands
{
    class LaunchGUI : Command
    {
        public LaunchGUI (String name) : base (name) { 
        }

        public override String execute (string[] args)
        {
            Kernel.res = true;
            if (Kernel.CanvasE == true)
                return "You are alerdy in GUI!";

            //Luanch gui

            return "Launched GUI";
        }
    }
}
