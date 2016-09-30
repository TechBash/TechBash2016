using System;

namespace Demo.SOLID
{
    public class LetterReportFormatter : ReportFormatter
    {
        public override void FormatReport()
        {
            Console.WriteLine("\nFormatting Report for 8-1/2x11...");
        }
    }
}