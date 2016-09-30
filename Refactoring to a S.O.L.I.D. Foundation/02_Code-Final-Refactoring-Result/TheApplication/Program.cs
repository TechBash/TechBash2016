using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReport report = new TabloidReport(new DotMatrixReportPrinter(new TabloidReportFormatter(), new ReportDataAccess()));

            report.Print();
            
            Console.WriteLine("\n\n\nProgram ended, hit any key to continue...");
            Console.ReadKey();
        }
    }
}
