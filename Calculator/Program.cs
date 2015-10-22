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
            Console.WriteLine("Calculator REPL. Please input simple two-component arithmetic expressions (i.e. 2 + 4)");
            Loop(Print);
        }

        static void Loop(Action<string> loopAction)
        {
            bool forceDone = false;
            do
            {
                while (!Console.KeyAvailable || forceDone)
                {
                    try
                    {
                        loopAction.Invoke(Eval(Read()));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        forceDone = true;
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape || forceDone);
        }
        
        static void Print(string output)
        {
            try
            {
                Console.WriteLine(output);
            }
            catch
            {
                throw;
            }
        }

        static string Eval(string input)
        {
            try
            {
                return input;
            }
            catch
            {
                throw;
            }
        }

        static string Read()
        {
            Console.Write(">>> ");
            return Console.ReadLine();
        }
    }
}
