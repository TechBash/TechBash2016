using System;

namespace Demo.SOLID
{
    public class TabloidReportPrinter : ReportPrinter
    {
        public override void Print()
        {
            Console.WriteLine("\nPrinting Report to Dot-Matrix Printer...");
        }
    }
}