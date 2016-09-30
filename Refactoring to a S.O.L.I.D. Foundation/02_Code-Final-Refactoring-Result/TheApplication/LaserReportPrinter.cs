using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
     public class LaserReportPrinter : ReportPrinter
    {
         private IReportDataAccess _dataAccess;
         private IReportFormatter _reportFormatter;

         public LaserReportPrinter(IReportFormatter reportFormatter, IReportDataAccess dataAccess)
         {
             _reportFormatter = reportFormatter;
             _dataAccess = dataAccess;
         }

         public override void Print()
        {
            _dataAccess.GetReportData();
            _reportFormatter.FormatReport();
            Console.WriteLine("\nPrinting Report to laser printer...");
        }
    }
}
