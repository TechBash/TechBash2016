using System;

namespace Demo.SOLID
{
    public abstract class ReportPrinter
    {
        public abstract void Print();
    }

    public class LetterReportPrinter : ReportPrinter
    {
        public override void Print()
        {
            Console.WriteLine("\nPrinting Report to Laser Printer...");
             
        }
    }

    public class TabloidReportPrinter : ReportPrinter
    {
        public override void Print()
        {
            Console.WriteLine("\nPrinting Report to Dot-Matrix Printer...");

            //base.Print();
        }
    }
}