using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
     public class LetterReportFormatter : ReportFormatter
    {
        public override void FormatReport()
        {
            Console.WriteLine("\nFormatting Report for 8-1/2 X 11...");
        }
    }
}
