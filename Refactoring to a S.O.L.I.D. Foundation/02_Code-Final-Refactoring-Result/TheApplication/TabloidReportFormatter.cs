using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
     public class TabloidReportFormatter : IReportFormatter
    {
        public  void FormatReport()
        {
            Console.WriteLine("\nFormatting Report for 11 X 17...");
            //base.FormatReport();
        }
    }
}
