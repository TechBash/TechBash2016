//namespace Demo.SOLID
//{
//    public class LetterReport : Report
//    {
//        private DataAccess _dataAccess;
//        private ReportFormatter _reportFormatter;
//        private ReportPrinter _reportPrinter;

//        public LetterReport(DataAccess dataAccess,
//            ReportFormatter reportFormatter, ReportPrinter reportPrinter)
//        {
//            _dataAccess = dataAccess;
//            _reportFormatter = reportFormatter;
//            _reportPrinter = reportPrinter;
//        }

//        public override void Print()
//        {
//            //_dataAccess = new DataAccess();
//            _dataAccess.GetData();

//            //_reportFormatter = new LetterReportFormatter();
//            _reportFormatter.FormatReport();

//            //_reportPrinter = new LetterReportPrinter();
//            _reportPrinter.Print();
//        }
//    }
//}
