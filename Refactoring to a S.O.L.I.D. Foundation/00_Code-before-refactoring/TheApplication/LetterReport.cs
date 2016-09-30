using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.SOLID
{
    public abstract class Report
    {
        public abstract void Print();
    }

    public class LetterReport : Report
    {
     public override void Print()
        {
         DataAccess dataAccess = new DataAccess();
         dataAccess.GetData();

         ReportFormatter reportFormatter = new LetterReportFormatter();
         reportFormatter.FormatReport();

         ReportPrinter reportPrinter = new LetterReportPrinter();
         reportPrinter.Print();
        }
    }

    public class TabloidReport : Report
    {
        public override void Print()
        {
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.GetData();

                ReportFormatter reportFormatter = new TabloidReportFormatter();
                reportFormatter.FormatReport();

                ReportPrinter reportPrinter = new TabloidReportPrinter();
                reportPrinter.Print();
            }
            //base.Print();
        }
    }
}
