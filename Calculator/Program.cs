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

        /// <summary>
        /// Loops the action until an error or the Escape key is pressed.
        /// The Escape key is often blocked due to Console.ReadLine, so 
        /// also keep Ctrl-C in mind.
        /// </summary>
        /// <param name="loopAction"></param>
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
        
        /// <summary>
        /// Prints the output it's given in a new line
        /// </summary>
        /// <param name="output"></param>
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

        /// <summary>
        /// Evaluates a string expression to an integer result using <see cref="Calculator"/>
        /// </summary>
        /// <param name="input">String expression to be evaluated. 
        /// Follows rules outlined in <see cref="Calculator.Create"/></param>
        /// <returns>Evaluated result of expression as a string</returns>
        static string Eval(string input)
        {
            Calculator calc;
            try
            {
                calc = Calculator.Create(input);
                return calc.Evaluate().ToString();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Reads in an expression (i.e. "2 + 2") from the console
        /// </summary>
        /// <returns>The console input</returns>
        static string Read()
        {
            Console.Write(">>> ");
            return Console.ReadLine();
        }
    }
}
