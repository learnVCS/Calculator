﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculator.Create(args[0] + " + " + args[1]).Evaluate());
            Console.ReadLine();
        }
    }
}
