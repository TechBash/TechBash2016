using System;

namespace Demo.SOLID
{
    public class TabloidReportFormatter : ReportFormatter
    {
        public override void FormatReport()
        {
            Console.WriteLine("\nFormatting Report for 11x17...");
        }
    }
}