using System;

namespace Demo.SOLID
{
    public class LetterReportPrinter : ReportPrinter
    {
        public override void Print()
        {
            Console.WriteLine("\nPrinting Report to Laser Printer...");
        }
    }
}