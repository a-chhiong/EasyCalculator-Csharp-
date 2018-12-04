using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyCalculatorLibrary;

namespace MyCalculatorConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyCompute SimpleCal = new MyCompute();

            Console.WriteLine("****************************************************************");
            Console.WriteLine("* This is a simple calculation demo programm.                  *");
            Console.WriteLine("* Support: integers, floatings, <+>, <->, <*>, </>, <(>, <)>.  *");
            Console.WriteLine("* Please input a proper numeric expression in following...     *");
            Console.WriteLine("* For example...                                               *");
            Console.WriteLine("* >  Start: 1.2+3.4-5.6*7.8/9.0                                *");
            Console.WriteLine("*                                  and then, press <Enter>...  *");
            Console.WriteLine("****************************************************************");

            while (true)
            {
                Console.Write("\n\r");
                Console.Write(">  Start: ");

                string input = Console.ReadLine();

                string output = SimpleCal.Execution(input);

                int count = SimpleCal.Before;
                int after = SimpleCal.After;
                int remain = SimpleCal.Remain;
                double answer = SimpleCal.Answer;

                Console.WriteLine("> Result: " + output);
                Console.WriteLine("------------------------------");
                Console.WriteLine("> Before: " + Convert.ToString(count));
                Console.WriteLine(">  After: " + Convert.ToString(after));
                Console.WriteLine("> Remain: " + Convert.ToString(remain));
                Console.WriteLine("> Answer: " + Convert.ToString(answer));
                Console.WriteLine("==============================");
                Console.Write("Press <Enter> for next calculation...");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Write("\n\r");
                }
                else
                {
                    break;
                }
            }
        }
    }
}