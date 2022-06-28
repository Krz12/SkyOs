using System;
using System.Collections.Generic;
using System.Text;

namespace SkyOs.Commands
{
    class Snake : Command
    {
        int Height = 20;
        int Width = 30;

        public Snake(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            void WriteBoard()
            {
                Console.Clear();
                for(int i = 1;i<=(Width+2);i++)
                {
                    Console.SetCursorPosition(i, 1);
                    Console.Write("-");
                }

                for (int i = 1; i <= (Width + 2); i++)
                {
                    Console.SetCursorPosition(i, (Height+2));
                    Console.Write("-");
                }
            }
            return "";
        }
    }
}
