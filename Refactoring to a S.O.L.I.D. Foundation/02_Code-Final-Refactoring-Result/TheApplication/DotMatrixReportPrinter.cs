using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
     public class DotMatrixReportPrinter : IReportPrinter
    {
         private IReportFormatter _reportFormatter;
         private IReportDataAccess _dataAccess;

         /// <summary>
         /// Initializes a new instance of the DotMatrixReportPrinter class.
         /// </summary>
         /// <param name="reportFormatter"></param>
         /// <param name="dataAccess"></param>
         public DotMatrixReportPrinter(IReportFormatter reportFormatter, IReportDataAccess dataAccess)
         {
             _reportFormatter = reportFormatter;
             _dataAccess = dataAccess;
         }

         public  void Print()
        {
            //_dataAccess = new ReportDataAccess();
            //_reportFormatter = new TabloidReportFormatter();
            _dataAccess.GetReportData();
            _reportFormatter.FormatReport();
            Console.WriteLine("\nPrinting Report to dot-matrix printer...");
            //base.Print();
        }
    }
}
