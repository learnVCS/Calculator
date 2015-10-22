using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        /// <summary>
        /// First number to be calculated
        /// </summary>
        public int Num1 { get; set; }

        /// <summary>
        /// Second number to be calculated
        /// </summary>
        public int Num2 { get; set; }

        /// <summary>
        /// Calculation operator
        /// </summary>
        /// <remarks>
        /// Currently supports '+', '-', '*', and '/'
        /// </remarks>
        public char Operator { get; set; }

        /// <summary>
        /// Default constructor, zeroes out numbers and does not set operator
        /// </summary>
        public Calculator() : this(default(int), default(int)) { }

        /// <summary>
        /// Initializes numbers but does not set operator.
        /// </summary>
        /// <param name="first">First number, initializes Num1.</param>
        /// <param name="second">Second number, initializes Num2. 
        /// If Operator gets set to '/', this cannot be 0.</param>
        public Calculator(int first, int second)
        {
            Num1 = first;
            Num2 = second;
        }

        /// <summary>
        /// Initializes numbers and sets operator.
        /// </summary>
        /// <param name="first">First number, initializes Num1.</param>
        /// <param name="second">Second number, initializes Num2. 
        /// If <paramref name="op"/> is '/', this cannot be 0.</param>
        /// <param name="op">Calculation operator, initializes Operator. 
        /// Should be '+', '-', '*', or '/'</param>
        public Calculator(int first, int second, char op) : this(first, second)
        {
            Operator = op;
        }

        /// <summary>
        /// Evaluates a string expression into a Calculator object.
        /// </summary>
        /// <param name="input">Expression to be evaluated.</param>
        /// <example>
        /// This example shows how to pass an expresison that can be parsed correctly
        /// <code>
        /// class Program
        /// {
        ///     static void Main(string[] args)
        ///     {
        ///         Console.WriteLine(Calculator.Create("18 - 3").Evaluate());
        ///         Console.WriteLine(Calculator.Create("95*-17").Evaluate());
        ///         Console.WriteLine(Calculator.Create("-40 +40").Evaluate());
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <returns>Calculator object with parsed values and operator</returns>
        public static Calculator Create(string input)
        {
            var expression = input.ToCharArray();
            int? num1 = null, num2 = null;
            char op = default(char), last = default(char);
            foreach (var element in expression)
            {
                int temp;
                if (int.TryParse(element.ToString(), out temp))
                {
                    if (op == default(char))
                    {
                        if (num1.HasValue)
                        {
                            if (num1 == -1)
                            {
                                num1 *= temp;
                            }
                            else
                            {
                                num1 *= 10;
                                num1 += temp;
                            }
                        }
                        else
                        {
                            num1 = temp;
                        }
                    }
                    else
                    {
                        if (num2.HasValue)
                        {
                            if (num2 == -1 && last == '-')
                            {
                                num2 *= temp;
                            }
                            else
                            {
                                num2 *= 10;
                                num2 += temp;
                            }
                        }
                        else
                        {
                            num2 = temp;
                        }
                    }
                }
                else if ("+-*/".IndexOf(element) != -1)
                {
                    if (element == '-' && !num1.HasValue)
                    {
                        num1 = -1;
                    }
                    else if (element == '-' && op != default(char) && !num2.HasValue)
                    {
                        num2 = -1;
                    }
                    else
                    {
                        op = element;
                    }
                }
                last = element;
            }
            return new Calculator(num1.Value, num2.Value) { Operator = op };
        }

        /// <summary>
        /// Evaluates Num1 and Num2 by Operator
        /// </summary>
        /// <returns>Result of calculation</returns>
        public int Evaluate()
        {
            switch (Operator)
            {
                case '+':
                    return Add();
                case '-':
                    return Subtract();
                case '*':
                    return Multiply();
                case '/':
                    return Divide();
                default:
                    throw new ArgumentException("Bad args punk");
            }
        }

        /// <summary>
        /// Adds Num1 and Num2
        /// </summary>
        /// <returns>The sum of Num1 and Num2</returns>
        public int Add()
        {
            return Num1 + Num2;
        }

        /// <summary>
        /// Subtracts Num1 and Num2
        /// </summary>
        /// <returns>The difference between Num1 and Num2</returns>
        public int Subtract()
        {
            return Num1 - Num2;
        }

        /// <summary>
        /// Multiplies Num1 and Num2
        /// </summary>
        /// <returns>The product of Num1 and Num2</returns>
        public int Multiply()
        {
            return Num1 * Num2;
        }

        /// <summary>
        /// Divides Num1 by Num2
        /// </summary>
        /// <remarks>
        /// If Num2 is 0, this method returns 0.
        /// </remarks>
        /// <returns>The quotient of Num1 and Num2</returns>
        public int Divide()
        {
            if (Num2 != 0)
                return Num1 / Num2;
            return 0;
        }
    }
}
