using System;
using System.Collections.Generic;
using System.Text;

namespace SkyOs.Commands
{
    class List : Command
    {
        public List(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = true;
            Console.WriteLine("-----------------------------List of commands-----------------------------");
            Console.WriteLine("1. shoutdown");
            Console.WriteLine("2. restart");
            Console.WriteLine("3. help");
            Console.WriteLine("4. file create,delete,createdir,deletedir,write,read,freespace,gfst,lsdir");
            Console.WriteLine("5. clear");
            Console.WriteLine("6. help menu,1,2,3,4,5,6,7,8,9");
            Console.WriteLine("7. launchgui");
            Console.WriteLine("8. time h,m,s,a");
            Console.WriteLine("9. date y,m,d,a");
            Console.WriteLine("10. run ca,");
            Console.WriteLine("11. SysInfo");
            Console.WriteLine("12. calc");
            return            "--------------------------------------------------------------------------";
        }
    }
}
