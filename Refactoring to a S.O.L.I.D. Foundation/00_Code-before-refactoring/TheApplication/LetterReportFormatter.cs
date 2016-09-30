using System;

namespace Demo.SOLID
{
    public abstract class ReportFormatter
    {
        public abstract void FormatReport();
    }

    public class LetterReportFormatter : ReportFormatter
    {
        public override void FormatReport()
        {
            Console.WriteLine("\nFormatting Report for 8-1/2x11...");
        }
    }

    public class TabloidReportFormatter : ReportFormatter
    {
        public override void FormatReport()
        {
            Console.WriteLine("\nFormatting Report for 11x17...");

            //base.FormatReport();
        }
    }
}