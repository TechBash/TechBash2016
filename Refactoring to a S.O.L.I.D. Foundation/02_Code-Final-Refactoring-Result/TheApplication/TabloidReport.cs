using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
    public class TabloidReport : Report
    {
        private IReportPrinter _reportPrinter;

        /// <summary>
        /// Initializes a new instance of the TabloidReport class.
        /// </summary>
        /// <param name="reportPrinter"></param>
        public TabloidReport(IReportPrinter reportPrinter)
        {
            _reportPrinter = reportPrinter;
        }

        public override void Print()
        {
            //_reportPrinter = new DotMatrixReportPrinter();
            _reportPrinter.Print();
            //base.Print();
        }
    }
}
