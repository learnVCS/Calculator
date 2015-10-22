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
            Loop(Print);
        }

        static void Loop(Action<string> loopAction)
        {
            do
            {
                loopAction.Invoke(Eval());
            } while (true);
        }

        static void Print(string output)
        {
            Console.WriteLine(output);
        }

        static string Eval()
        {
            return (Convert.ToInt32(Read()) + Convert.ToInt32(Read())).ToString();
        }

        public static string Read()
        {
            Console.Write(">>> ");
            return Console.ReadLine();
        }
    }
}
