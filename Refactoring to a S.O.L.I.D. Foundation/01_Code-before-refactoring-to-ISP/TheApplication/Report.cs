namespace Demo.SOLID
{
    public  class Report
    {
        private DataAccess _dataAccess;
        private ReportFormatter _reportFormatter;
        private ReportPrinter _reportPrinter;

        public Report(DataAccess dataAccess,
            ReportFormatter reportFormatter, ReportPrinter reportPrinter)
        {
            _dataAccess = dataAccess;
            _reportFormatter = reportFormatter;
            _reportPrinter = reportPrinter;
        }

        public void Print()
        {
            //_dataAccess = new DataAccess();
            _dataAccess.GetData();

            //_reportFormatter = new TabloidReportFormatter();
            _reportFormatter.FormatReport();

            //_reportPrinter = new TabloidReportPrinter();
            _reportPrinter.Print();
        }
    }
}