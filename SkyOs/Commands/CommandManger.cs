using System;
using System.Collections.Generic;
using System.Text;

namespace SkyOs.Commands
{
    public class CommandManger
    {
        private List<Command> commands;

        public CommandManger ()
        {
            this.commands = new List<Command>();
            this.commands.Add(new Help("help"));
            this.commands.Add(new File("file"));
            this.commands.Add(new LaunchGUI("launchgui"));
            this.commands.Add(new Clear("clear"));
            this.commands.Add(new Shoutdown("shoutdown"));
            this.commands.Add(new Restart("restart"));
            this.commands.Add(new Time("time"));
            this.commands.Add(new Date("date"));
            this.commands.Add(new Run("run"));
            this.commands.Add(new SysInfo("sysinfo"));
            this.commands.Add(new Calculator("calc"));
            this.commands.Add(new List("list"));
            this.commands.Add(new Color("color"));
            this.commands.Add(new Install("install"));
            this.commands.Add(new Settings("settings"));
            this.commands.Add(new cd("cd"));
            this.commands.Add(new lsdir("lsdir"));
            this.commands.Add(new create("create"));
            this.commands.Add(new createdir("createdir"));
            this.commands.Add(new delete("delete"));
            this.commands.Add(new deletedir("deletedir"));
            this.commands.Add(new delsys("delsys"));
            this.commands.Add(new write("write"));
            this.commands.Add(new Read("read"));
            this.commands.Add(new freespace("freespace"));
            this.commands.Add(new gfst("gfst"));
            this.commands.Add(new up("\\"));
            this.commands.Add(new sus("sus"));
            this.commands.Add(new Utilities("Utilities"));
        }

        public String processInput (string input)
        {
            
            String[] split=input.Split(' ');
            
            String label = split[0];

            List<String> args=new List<String>();

            int ctr = 0;
            foreach (String s in split)
            {
                if (ctr != 0)
                    args.Add(s);
                ++ctr;
            }
            
            foreach (Command cmd in this.commands)
            {
                if (cmd.name == label)
                   return cmd.execute(args.ToArray());
            }

            return "Your command \"" + label + "\" does not exist!";
        }
        public String processInput(string input, string Text)
        {

            String[] split = input.Split(' ');

            String label = split[0];

            List<String> args = new List<String>();

            int ctr = 0;
            foreach (String s in split)
            {
                if (ctr != 0)
                    args.Add(s);
                ++ctr;
            }

            foreach (Command cmd in this.commands)
            {
                if (cmd.name == label)
                    return cmd.execute(args.ToArray());
            }

            return "Your command \"" + label + "\" does not exist!";
        }
    }
}
