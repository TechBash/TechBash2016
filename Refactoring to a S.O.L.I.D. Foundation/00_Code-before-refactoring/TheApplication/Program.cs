using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            Report report = new LetterReport();

            report.Print();
            
            Console.WriteLine("\n\n\nProgram ended, hit any key to continue...");
            Console.ReadKey();
        }
    }
}
