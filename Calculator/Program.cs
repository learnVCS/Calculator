using System;
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
            Console.WriteLine(Convert.ToInt32(args[0]) + Convert.ToInt32(args[1]));
        }
    }
}
