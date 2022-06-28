using System;
using System.Collections.Generic;
using System.Text;

namespace SkyOs.Commands
{
    class Calculator : Command
    {
        public Calculator(String name) : base(name)
        {

        }

        public override string execute(string[] args)
        {
            Kernel.res = false;
            Double firstnum;
            Double secondnumber;
            Double answer;
            string ops;

            Console.WriteLine("---------Caluculator---------\r");

            Console.WriteLine("Enter first number\n");
            firstnum = Double.Parse(Console.ReadLine());

            Console.WriteLine("Select an Operator: (+, -, *, /, %, ^)\n");
            ops = Console.ReadLine();

            Console.WriteLine("Enter second number\n");
            secondnumber = Double.Parse(Console.ReadLine());

            if (ops == "+")
            {
                answer = firstnum + secondnumber;
                Console.WriteLine(answer);
            }

            if (ops == "-")
            {
                answer = firstnum - secondnumber;
                Console.WriteLine(answer);
            }

            if (ops == "*")
            {
                answer = firstnum * secondnumber;
                Console.WriteLine(answer);
            }

            if (ops == "/")
            {
                answer = firstnum / secondnumber;
                Console.WriteLine(answer);
            }

            if (ops == "%")
            {
                answer = firstnum % secondnumber;
                Console.WriteLine(answer);
            }

            Console.ReadKey();

            return "";
        }
    }
}
