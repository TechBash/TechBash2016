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
            Report report = new Report(new DataAccess(),
                new LetterReportFormatter(), new LetterReportPrinter());

            //Report report = new LetterReport(new DataAccess(),
            //    new LetterReportFormatter(), new LetterReportPrinter());

            report.Print();
            
            Console.WriteLine("\n\n\nProgram ended, hit any key to continue...");
            Console.ReadKey();
        }
    }
}
