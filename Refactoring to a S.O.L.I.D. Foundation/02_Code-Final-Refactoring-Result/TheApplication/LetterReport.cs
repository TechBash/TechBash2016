using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
    public class LetterReport : Report
    {
        private IReportPrinter _reportPrinter;

        public LetterReport(IReportPrinter reportPrinter)
        {
            _reportPrinter = reportPrinter;
        }

        public override void Print()
        {
            _reportPrinter.Print();
        }
    }
}
